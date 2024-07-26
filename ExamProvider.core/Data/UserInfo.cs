using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class UserInfo
    {
        
        public decimal UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public decimal? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual UserRole? Role { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
