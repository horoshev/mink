using Mink.Domain.Models.Dtos;
using Mink.Domain.Models.Entities;

namespace Mink.Services.Common
{
    public static class Mapper
    {
        public static MinifiedUriDto ToDto(this MinifiedUri entity)
        {
            return new()
            {
                Id = entity.Id,
                OriginUri = entity.OriginUri,
                MinifiedUriKey = entity.MinifiedUriKey,
                QrImageUri = entity.QrImageUri,
            };
        }

        public static MinifiedUri ToEntity(this MinifiedUriDto dto)
        {
            return new()
            {
                Id = dto.Id,
                OriginUri = dto.OriginUri,
                MinifiedUriKey = dto.MinifiedUriKey,
                QrImageUri = dto.QrImageUri,
            };
        }
    }
}