using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class UserRolePackageConstant
    {
        // Stored procedure names
        public const string USER_ROLE_PACKAGE_CREATE_ROLE = "USER_ROLE_PACKAGE.CREATE_USER_ROLE";
        public const string USER_ROLE_PACKAGE_UPDATE_ROLE = "USER_ROLE_PACKAGE.UPDATE_USER_ROLE";
        public const string USER_ROLE_PACKAGE_DELETE_ROLE = "USER_ROLE_PACKAGE.DELETE_USER_ROLE";
        public const string USER_ROLE_PACKAGE_GET_ROLE_BY_ID = "USER_ROLE_PACKAGE.get_user_role_by_id";
        public const string USER_ROLE_PACKAGE_GET_ALL_ROLES = "USER_ROLE_PACKAGE.get_all_user_roles";

        // Parameter names
        public const string V_ROLE_ID = "V_ROLE_ID";
        public const string V_ROLE_NAME = "V_ROLE_NAME";
    }

}
