using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class UpdateExamDTO
    {
        public decimal ExamId { get; set; }
        public string? ExamName { get; set; }
        public decimal? ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
    }

}
