using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProviderMVC.ViewModels
{
    public class QuestionOptionViewModel
    {
        public decimal OptionId { get; set; }
        public string? Title { get; set; }
        public string? IsCorrect { get; set; }
        public decimal? QuestionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

}
