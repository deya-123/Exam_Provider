using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class CreateExamDTO
    {
        [Required(ErrorMessage = "Exam Name is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Exam Name must be at least 6 characters long")]
        public string? ExamName { get; set; }
        [Required(ErrorMessage = "Exam Duration is required")]
        public decimal? ExamDuration { get; set; }
        [Required(ErrorMessage = "Exam Description is required")]
        public string? ExamDescription { get; set; }
    }

}
