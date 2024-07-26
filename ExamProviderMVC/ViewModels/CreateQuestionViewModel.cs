using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProviderMVC.ViewModels
{
    public class CreateQuestionViewModel
    {
        [Required(ErrorMessage = "Question Description is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Description must be at least 6 characters long")]
        public string? QuestionDescription { get; set; }
        [Required(ErrorMessage = "Question Level is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Level must be at least 6 characters long")]
        public string? QuestionLevel { get; set; }
        [Required(ErrorMessage = "Question Type is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Type must be at least 6 characters long")]
        public string? QuestionType { get; set; }
        public decimal? ExamId { get; set; }
    }

}
