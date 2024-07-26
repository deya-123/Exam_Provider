using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class Question
    {
        

        public decimal QuestionId { get; set; }
        public string? QuestionDescription { get; set; }
        public string? QuestionLevel { get; set; }
        public string? QuestionType { get; set; }
        public decimal? ExamId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
