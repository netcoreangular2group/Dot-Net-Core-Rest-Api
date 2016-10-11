using System;
using KPI.Infrastructure;

namespace KPI.Core.Domain
{
    public class UserAddress : Entity
    {
        public long UserId { get; set; }

        //public virtual User User { get; set; }

        public long AddressId { get; set; }

        public virtual Address Address { get; set; }

        public AddressType AddressType { get; set; }

        public DateTimeOffset? LastUsedOn { get; set; }
    }
}
