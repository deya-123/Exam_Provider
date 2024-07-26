using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProviderMVC.ViewModels
{
    public class CreateQuestionOptionViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Title must be at least 6 characters long")]
        public string? Title { get; set; }
        public string? IsCorrect { get; set; }
        public decimal? QuestionId { get; set; }
    }

}
