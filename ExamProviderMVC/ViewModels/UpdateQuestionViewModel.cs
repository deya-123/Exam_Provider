using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProviderMVC.ViewModels
{
    public class UpdateQuestionViewModel
    {
        public string? QuestionDescription { get; set; }
        public decimal? QuestionId { get; set; }
        public string? QuestionLevel { get; set; }
        public string? QuestionType { get; set; }
        public decimal? ExamId { get; set; }
    }

}
