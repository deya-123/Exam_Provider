﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProviderMVC.ViewModels
{
    public class UpdateApiServiceViewModel
    {
        public decimal ApiServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? UniqueKey { get; set; }
    }

}
