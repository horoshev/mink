using System;

namespace Mink.Domain.Models.Entities
{
    public class MinifiedUri : Entity<Guid>
    {
        public string OriginUri { get; set; }
        public string MinifiedUriKey { get; set; }
        public string QrImageUri { get; set; }
    }
}