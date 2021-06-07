using System;

namespace Mink.Domain.Models.Dtos
{
    public class MinifiedUriDto : EntityDto<Guid>
    {
        public string OriginUri { get; set; }
        public string MinifiedUriKey { get; set; }
        public string QrImageUri { get; set; }
    }
}