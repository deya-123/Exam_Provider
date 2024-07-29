using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using ExamProvider.infra.Mapper;
using ExamProvider.infra.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Repositary
{
    public class ApiInfoRepository : IApiInfoRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public ApiInfoRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<ApiServiceDTO>.SetTypeMap();
        }

        public async Task CreateApiInfo(CreateApiServiceDTO createApiServiceDTO)
        {
            DynamicParameters param = new();
            param.Add(name: ApiServicePackageConstant.V_SERVICE_NAME, createApiServiceDTO.ServiceName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ApiServicePackageConstant.V_UNIQUE_KEY, createApiServiceDTO.UniqueKey, dbType: DbType.String, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ApiServicePackageConstant.API_SERVICE_PACKAGE_CREATE_SERVICE, param, commandType: CommandType.StoredProcedure);

        }

        public async Task DeleteApiInfo(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: ApiServicePackageConstant.V_API_SERVICE_ID, id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ApiServicePackageConstant.API_SERVICE_PACKAGE_DELETE_SERVICE, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateApiInfo(UpdateApiServiceDTO updateApiServiceDTO)
        {
            DynamicParameters param = new();
            param.Add(name: ApiServicePackageConstant.V_API_SERVICE_ID, updateApiServiceDTO.ApiServiceId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: ApiServicePackageConstant.V_SERVICE_NAME, updateApiServiceDTO.ServiceName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ApiServicePackageConstant.V_UNIQUE_KEY, updateApiServiceDTO.UniqueKey, dbType: DbType.String, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ApiServicePackageConstant.API_SERVICE_PACKAGE_UPDATE_SERVICE, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ApiServiceDTO>> GetAllApisInfo()
        {
            var res = await _dbContext.Connection.QueryAsync<ApiServiceDTO>(ApiServicePackageConstant.API_SERVICE_PACKAGE_GET_ALL_SERVICES, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }
     


        public async Task<string> GetKeyByServiceName(string serviceName= "exam guardian")
        {
            var apiKey = await _modelContext.ApiServices.
                FirstOrDefaultAsync(e => e.ServiceName != null&& e.ServiceName.ToLower() == serviceName.ToLower());

            if (apiKey is null || apiKey.UniqueKey is null) {

                throw new InvalidOperationException("API key not found.");
            }
            return apiKey.UniqueKey;
        }
        public async Task<ApiServiceDTO> GetApiInfoById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: ApiServicePackageConstant.V_API_SERVICE_ID, id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<ApiServiceDTO>(ApiServicePackageConstant.API_SERVICE_PACKAGE_GET_SERVICE_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault();
        }
    }
}
