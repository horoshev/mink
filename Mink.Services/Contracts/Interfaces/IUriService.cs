using System.Threading.Tasks;
using Mink.Domain.Models.Dtos;
using Mink.Services.Contracts.Models;

namespace Mink.Services.Contracts.Interfaces
{
    public interface IUriService
    {
        Task<ServiceResult<MinifiedUriDto>> CreateMinifiedUri(MinifiedUriDto dto);
        ServiceResult<string> ResolveKey(string key);
    }
}