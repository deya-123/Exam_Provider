using ExamProvider.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class ExamDetailsWithoutAnwersDTO
    {
        public string? ExamName { get; set; }
        public decimal? ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
        public decimal? Price { get; set; }

        public virtual IEnumerable<QuestionWithoutAnswerDTO> Questions { get; set; }
   
    }
}
