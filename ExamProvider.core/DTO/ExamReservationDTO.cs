using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class ExamReservationDTO
    {
        public string? ExamName { get; set; }
        public decimal? ScoreMark { get; set; }
        public string? StudentName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
