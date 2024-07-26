using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class ApiServicePackageConstant
    {
        public const string API_SERVICE_PACKAGE_CREATE_SERVICE = "API_SERVICE_PACKAGE.create_api_service";
        public const string API_SERVICE_PACKAGE_DELETE_SERVICE = "API_SERVICE_PACKAGE.delete_api_service";
        public const string API_SERVICE_PACKAGE_UPDATE_SERVICE = "API_SERVICE_PACKAGE.update_api_service";
        public const string API_SERVICE_PACKAGE_GET_SERVICE_BY_ID = "API_SERVICE_PACKAGE.get_api_service_by_id";
        public const string API_SERVICE_PACKAGE_GET_ALL_SERVICES = "API_SERVICE_PACKAGE.get_all_api_services";

        // Parameter names
        public const string V_API_SERVICE_ID = "v_api_service_id";
        public const string V_SERVICE_NAME = "v_service_name";
        public const string V_UNIQUE_KEY = "v_unique_key";
    }
}
