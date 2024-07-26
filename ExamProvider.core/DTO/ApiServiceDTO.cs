using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class ApiServiceDTO
    {
        public decimal ApiServiceId { get; set; }
        public string? ServiceName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UniqueKey { get; set; }
    }

}
