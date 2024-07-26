using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using ExamProvider.infra.Mapper;
using ExamProvider.infra.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Repositary
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        private readonly IDbContext _dbContext;

        public CompanyInfoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<CompanyInfoDTO>.SetTypeMap();
        }

        public async Task CreateCompanyInfo(CreateCompanyInfoDTO companyInfo)
        {
            DynamicParameters param = new();
            param.Add(name: CompanyInfoPackageConstant.V_ORGANIZATION_NAME, value: companyInfo.OrganizationName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: CompanyInfoPackageConstant.V_COMMERCIAL_RECORD_IMG, value: companyInfo.CommercialRecordImg, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: CompanyInfoPackageConstant.V_LOGO_IMAGE, value: companyInfo.LogoImage, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: CompanyInfoPackageConstant.V_DESCRIPTION, value: companyInfo.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.ExecuteAsync(CompanyInfoPackageConstant.COMPANY_INFO_PACKAGE_CREATE_INFO, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteCompanyInfo(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: CompanyInfoPackageConstant.V_COMPANY_INFO_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.ExecuteAsync(CompanyInfoPackageConstant.COMPANY_INFO_PACKAGE_DELETE_INFO, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateCompanyInfo(UpdateCompanyInfoDTO companyInfo)
        {
            DynamicParameters param = new();
            param.Add(name: CompanyInfoPackageConstant.V_COMPANY_INFO_ID, value: companyInfo.CompanyInfoId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: CompanyInfoPackageConstant.V_ORGANIZATION_NAME, value: companyInfo.OrganizationName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: CompanyInfoPackageConstant.V_COMMERCIAL_RECORD_IMG, value: companyInfo.CommercialRecordImg, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: CompanyInfoPackageConstant.V_LOGO_IMAGE, value: companyInfo.LogoImage, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: CompanyInfoPackageConstant.V_DESCRIPTION, value: companyInfo.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.ExecuteAsync(CompanyInfoPackageConstant.COMPANY_INFO_PACKAGE_UPDATE_INFO, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<CompanyInfoDTO> GetCompanyInfoById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: CompanyInfoPackageConstant.V_COMPANY_INFO_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<CompanyInfoDTO>(CompanyInfoPackageConstant.COMPANY_INFO_PACKAGE_GET_INFO_BY_ID, param, commandType: CommandType.StoredProcedure);

            return res;
        }

        public async Task<List<CompanyInfoDTO>> GetCompaniesInfo()
        {
            var res = await _dbContext.Connection.QueryAsync<CompanyInfoDTO>(CompanyInfoPackageConstant.COMPANY_INFO_PACKAGE_GET_ALL_INFO, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }
    }

}
