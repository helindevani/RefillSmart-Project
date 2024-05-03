﻿using back_end.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace back_end.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public ICollection<AdminRequest>? AdminRequests { get; set; }
    }
}
