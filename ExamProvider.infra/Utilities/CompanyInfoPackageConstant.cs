using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class CompanyInfoPackageConstant
    {
        public const string COMPANY_INFO_PACKAGE_CREATE_INFO = "COMPANY_INFO_PACKAGE.create_company_info";
        public const string COMPANY_INFO_PACKAGE_DELETE_INFO = "COMPANY_INFO_PACKAGE.delete_company_info_hard";
        public const string COMPANY_INFO_PACKAGE_UPDATE_INFO = "COMPANY_INFO_PACKAGE.update_company_info";
        public const string COMPANY_INFO_PACKAGE_GET_INFO_BY_ID = "COMPANY_INFO_PACKAGE.get_company_info_by_id";
        public const string COMPANY_INFO_PACKAGE_GET_ALL_INFO = "COMPANY_INFO_PACKAGE.get_all_company_infos";

        // Parameter names
        public const string V_COMPANY_INFO_ID = "v_company_info_id";
        public const string V_ORGANIZATION_NAME = "v_organization_name";
        public const string V_COMMERCIAL_RECORD_IMG = "v_commercial_record_img";
        public const string V_LOGO_IMAGE = "v_logo_image";
        public const string V_DESCRIPTION = "v_description";
        public const string V_CREATED_AT = "V_CREATED_AT";
        public const string V_UPDATED_AT = "V_UPDATED_AT";
        public const string V_DELETED_AT = "V_DELETED_AT";
    }

}
