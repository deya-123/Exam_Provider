using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class UserInfoDTO
    {
        public decimal UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public decimal? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
