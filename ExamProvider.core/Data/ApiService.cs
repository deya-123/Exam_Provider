using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class ApiService
    {
        public decimal ApiServiceId { get; set; }
        public string? ServiceName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UniqueKey { get; set; }
    }
}
