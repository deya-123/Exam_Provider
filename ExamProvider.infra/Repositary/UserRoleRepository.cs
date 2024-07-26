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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IDbContext _dbContext;

        public UserRoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<UserRoleDTO>.SetTypeMap();
        }


        public async Task CreateUserRole(CreateUserRoleDTO userRole)
        {
            DynamicParameters param = new();
            param.Add(name: UserRolePackageConstant.V_ROLE_NAME, value: userRole.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserRolePackageConstant.USER_ROLE_PACKAGE_CREATE_ROLE, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateUserRole(UpdateUserRoleDTO userRole)
        {
            DynamicParameters param = new();
            param.Add(name: UserRolePackageConstant.V_ROLE_ID, value: userRole.RoleId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserRolePackageConstant.V_ROLE_NAME, value: userRole.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserRolePackageConstant.USER_ROLE_PACKAGE_UPDATE_ROLE, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteUserRole(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: UserRolePackageConstant.V_ROLE_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserRolePackageConstant.USER_ROLE_PACKAGE_DELETE_ROLE, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<UserRoleDTO>> GetUserRoles()
        {
            var res = await _dbContext.Connection.QueryAsync<UserRoleDTO>(UserRolePackageConstant.USER_ROLE_PACKAGE_GET_ALL_ROLES, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task<UserRoleDTO> GetUserRoleById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: UserRolePackageConstant.V_ROLE_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<UserRoleDTO>(UserRolePackageConstant.USER_ROLE_PACKAGE_GET_ROLE_BY_ID, param, commandType: CommandType.StoredProcedure);

            return res;
        }
    }

}