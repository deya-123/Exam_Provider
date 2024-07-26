using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class StudentDTO
    {
        public decimal? UserId { get; set; }
        public string? UserName { get; set; }
        public string? BirthDate { get; set; }
        public string? UserEmail { get; set; }
   
        public DateTime? CreatedAt { get; set; }
        
    }
}
