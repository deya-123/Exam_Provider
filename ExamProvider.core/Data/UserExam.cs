using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class UserExam
    {
        public decimal UserExamId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? ExamId { get; set; }
        public decimal? UniqueId { get; set; }
        public decimal? ScoreMark { get; set; }
        public string? ScoreRate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual UserInfo? User { get; set; }
    }
}
