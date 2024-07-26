using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class UserInfoPackageConstant
    {
        // Stored procedure names
        public const string USER_INFO_PACKAGE_CREATE_USER_INFO = "USER_INFO_PACKAGE.CREATE_USER_INFO";
        public const string USER_INFO_PACKAGE_UPDATE_USER_INFO = "USER_INFO_PACKAGE.UPDATE_USER_INFO";
        public const string USER_INFO_PACKAGE_DELETE_USER_INFO = "USER_INFO_PACKAGE.DELETE_USER_INFO";
        public const string USER_INFO_PACKAGE_GET_USER_INFO_BY_ID = "USER_INFO_PACKAGE.GET_USER_INFO_BY_ID";
        public const string USER_INFO_PACKAGE_GET_ALL_USERS_INFO = "USER_INFO_PACKAGE.GET_ALL_USERS_INFO";

        // Parameter names
        public const string V_USER_ID = "V_USER_ID";
        public const string V_USER_NAME = "V_USER_NAME";
        public const string V_BIRTH_DATE = "V_BIRTH_DATE";
        public const string V_USER_EMAIL = "V_USER_EMAIL";
        public const string V_USER_PASSWORD = "V_USER_PASSWORD";
        public const string V_ROLE_ID = "V_ROLE_ID";
    }

}
