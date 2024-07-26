﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.DTO
{
    public class UserExamDTO
    {
        public decimal UserExamId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? ExamId { get; set; }
        public decimal? UniqueId { get; set; }
        public decimal? ScoreMark { get; set; }
        public string? ScoreRate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
