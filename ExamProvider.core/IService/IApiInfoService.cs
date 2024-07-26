using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IApiInfoService
    {
        Task<List<ApiServiceDTO>> GetAllApisInfo();
        Task<ApiServiceDTO> GetApiInfoById(decimal id);
        Task CreateApiInfo(CreateApiServiceDTO apiservice);
        Task UpdateApiInfo(UpdateApiServiceDTO apiservice);
        Task DeleteApiInfo(decimal id);
    }
}
