﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProviderMVC.ViewModels
{
    public class UpdateCompanyInfoViewModel
    {
        public decimal CompanyInfoId { get; set; }
        public string? OrganizationName { get; set; }
        public string? CommercialRecordImg { get; set; }
        public string? LogoImage { get; set; }
        public string? Description { get; set; }
    }

}
