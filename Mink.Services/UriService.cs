using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HashidsNet;
using Mink.Domain.Interfaces;
using Mink.Domain.Models.Dtos;
using Mink.Domain.Models.Entities;
using Mink.Services.Common;
using Mink.Services.Contracts.Interfaces;
using Mink.Services.Contracts.Models;

namespace Mink.Services
{
    public class UriService : IUriService
    {
        private readonly HttpClient _httpClient;
        private readonly IRepository<MinifiedUri> _uriRepository;

        public UriService(HttpClient client, IRepository<MinifiedUri> uriRepository)
        {
            _httpClient = client;
            _uriRepository = uriRepository;
        }

        /// <summary>
        /// Добавляет запись в базу, если пройдены проверки.
        /// </summary>
        /// <param name="dto">Данные для записи.</param>
        /// <returns>Добавленная запись с URI.</returns>
        public async Task<ServiceResult<MinifiedUriDto>> CreateMinifiedUri(MinifiedUriDto dto)
        {
            var (isValid, error) = await ValidateUri(dto.OriginUri);

            if (!isValid)
                return ServiceResult.Fail<MinifiedUriDto>(error);

            dto.MinifiedUriKey = GenerateKey(dto);
            var saved = SaveMinifiedUri(dto).ToDto();

            return ServiceResult.Success(saved);
        }

        /// <summary>
        /// Поиск исходного URI по ключу.
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Найденый результат.</returns>
        public ServiceResult<string> ResolveKey(string? key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return ServiceResult.Fail<string>(ServiceError.UriKeyNotFound);

            var minifiedUri = _uriRepository
                .Get(x => x.MinifiedUriKey == key)
                .FirstOrDefault();

            if (minifiedUri is null)
                return ServiceResult.Fail<string>(ServiceError.UriKeyNotFound);

            return ServiceResult.Success(minifiedUri.OriginUri);
        }

        /// <summary>
        /// Генерирует ключ для URI.
        /// </summary>
        /// <param name="dto">Данные по URI.</param>
        /// <returns>Уникальный ключ.</returns>
        private string GenerateKey(MinifiedUriDto dto)
        {
            var encoder = new Hashids(minHashLength: 8);
            var hash = dto.GetHashCode();
            var key = "";

            do
            {
                key = encoder.Encode(hash);
            } while (ResolveKey(key).IsSuccess);

            return key;
        }

        /// <summary>
        /// Проверяет формат URI и его доступность
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private async Task<(bool isValid, string error)> ValidateUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return (false, ServiceError.InvalidUriFormat);

            var response = await _httpClient.GetAsync(uri);
            if ((int) response.StatusCode >= 300)
                return (false, ServiceError.InvalidUriType);

            return (true, string.Empty);
        }

        /// <summary>
        /// Добавляет запись в базу используя репозиторий.
        /// </summary>
        /// <param name="dto">Данные для сохранения.</param>
        /// <returns>Добавленная запись.</returns>
        private MinifiedUri SaveMinifiedUri(MinifiedUriDto dto)
        {
            var entity = dto.ToEntity(); // entity.Id = Guid.NewGuid();
            var added = _uriRepository.Add(entity);
            _uriRepository.Save();

            return added;
        }
    }
}