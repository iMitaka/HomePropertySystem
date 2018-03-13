using System;
using System.Collections.Generic;
using System.Text;

namespace HomePropertySystem.Models.EntityHelpers
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class BaseUserEntity : IdentityUser
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
