using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class UserRole
    {
        
 

        public decimal RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
