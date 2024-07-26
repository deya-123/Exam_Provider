using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class CreateQuestionOptionDTO
    {
        public string? Title { get; set; }
        public string? IsCorrect { get; set; }
        public decimal? QuestionId { get; set; }
    }

}
