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
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public UserInfoRepository(IDbContext dbContext,ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<UserInfoDTO>.SetTypeMap();
        }


        public async Task CreateUserInfo(CreateUserInfoDTO userInfo)
        {
            DynamicParameters param = new();
            param.Add(name: UserInfoPackageConstant.V_USER_NAME, value: userInfo.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_BIRTH_DATE, value: userInfo.BirthDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_USER_EMAIL, value: userInfo.UserEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_USER_PASSWORD, value: userInfo.UserPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_ROLE_ID, value: userInfo.RoleId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserInfoPackageConstant.USER_INFO_PACKAGE_CREATE_USER_INFO, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateUserInfo(UpdateUserInfoDTO userInfo)
        {
            DynamicParameters param = new();
            param.Add(name: UserInfoPackageConstant.V_USER_ID, value: userInfo.UserId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_USER_NAME, value: userInfo.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_BIRTH_DATE, value: userInfo.BirthDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_USER_EMAIL, value: userInfo.UserEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_USER_PASSWORD, value: userInfo.UserPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: UserInfoPackageConstant.V_ROLE_ID, value: userInfo.RoleId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserInfoPackageConstant.USER_INFO_PACKAGE_UPDATE_USER_INFO, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteUserInfo(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: UserInfoPackageConstant.V_USER_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserInfoPackageConstant.USER_INFO_PACKAGE_DELETE_USER_INFO, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<UserInfoDTO>> GetUsersInfo()
        {
            var res = await _dbContext.Connection.QueryAsync<UserInfoDTO>(UserInfoPackageConstant.USER_INFO_PACKAGE_GET_ALL_USERS_INFO, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task<UserInfoDTO> GetUserInfoById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: UserInfoPackageConstant.V_USER_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<UserInfoDTO>(UserInfoPackageConstant.USER_INFO_PACKAGE_GET_USER_INFO_BY_ID, param, commandType: CommandType.StoredProcedure);

            return res;
        }

        public async Task<List<StudentDTO>> GetStudents()
        {
           return await _modelContext.UserInfos.Where(e=>e.RoleId==2).Select(e=>new StudentDTO
           {
               UserId = e.UserId,
               UserName = e.UserName,
               UserEmail =e.UserEmail,
               BirthDate= e.BirthDate != null ? e.BirthDate.Value.Date.ToLongDateString() : null,
               CreatedAt = e.CreatedAt,
           }).ToListAsync();
        }
    }
}


