using System;
using System.Collections.Generic;

namespace ExamProvider.core.Data
{
    public partial class CompanyInfo
    {
        public decimal CompanyInfoId { get; set; }
        public string? OrganizationName { get; set; }
        public string? CommercialRecordImg { get; set; }
        public string? LogoImage { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
