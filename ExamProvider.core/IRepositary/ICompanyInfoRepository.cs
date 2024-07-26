using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface ICompanyInfoRepository
    {
        Task<List<CompanyInfoDTO>> GetCompaniesInfo();
        Task<CompanyInfoDTO> GetCompanyInfoById(decimal id);
        Task CreateCompanyInfo(CreateCompanyInfoDTO companyInfo);
        Task UpdateCompanyInfo(UpdateCompanyInfoDTO companyInfo);
        Task DeleteCompanyInfo(decimal id);
    }
}