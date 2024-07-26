using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProviderMVC.ViewModels
{
    public class UpdateExamViewModel
    {
        public decimal ExamId { get; set; }
        public string? ExamName { get; set; }
        public decimal? ExamDuration { get; set; }
        public string? ExamDescription { get; set; }
    }

}
