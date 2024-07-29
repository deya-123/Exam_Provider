using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using ExamProvider.infra.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class ApiInfoService : IApiInfoService
    {
        private readonly IApiInfoRepository _apiInfoRepository;

        public ApiInfoService(IApiInfoRepository apiInfoRepository)
        {
            _apiInfoRepository = apiInfoRepository;
        }

        public async Task CreateApiInfo(CreateApiServiceDTO createApiServiceDTO)
        {
            await _apiInfoRepository.CreateApiInfo(createApiServiceDTO);
        }

        public async Task DeleteApiInfo(decimal id)
        {
            await _apiInfoRepository.DeleteApiInfo(id);
        }

        public async Task<List<ApiServiceDTO>> GetAllApisInfo()
        {
           return await _apiInfoRepository.GetAllApisInfo();
        }

        public async Task<ApiServiceDTO> GetApiInfoById(decimal id)
        {
          return  await _apiInfoRepository.GetApiInfoById(id);
        }

        public async Task<string> GetKeyByServiceName(string serviceName = "exam guardian")
        {
            return await _apiInfoRepository.GetKeyByServiceName(serviceName);
        }

        public async Task UpdateApiInfo(UpdateApiServiceDTO updateApiServiceDTO)
        {
            await _apiInfoRepository.UpdateApiInfo(updateApiServiceDTO);
        }

    }
}
