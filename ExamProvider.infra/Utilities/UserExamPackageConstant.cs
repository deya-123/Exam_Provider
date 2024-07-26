using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class UserExamPackageConstant
    {
        // Stored procedure names
        public const string USER_EXAM_PACKAGE_CREATE_EXAM_USER = "USER_EXAM_PACKAGE.create_user_exam";
        public const string USER_EXAM_PACKAGE_UPDATE_EXAM_USER = "USER_EXAM_PACKAGE.update_user_exam";
        public const string USER_EXAM_PACKAGE_DELETE_EXAM_USER = "USER_EXAM_PACKAGE.delete_user_exam";
        public const string USER_EXAM_PACKAGE_GET_EXAM_USER_BY_ID = "USER_EXAM_PACKAGE.get_user_exam_by_id";
        public const string USER_EXAM_PACKAGE_GET_ALL_EXAMS_USER = "USER_EXAM_PACKAGE.get_all_user_exams";

        // Parameter names
        public const string V_USER_EXAM_ID = "V_USER_EXAM_ID";
        public const string V_USER_ID = "V_USER_ID";
        public const string V_EXAM_ID = "V_EXAM_ID";
        public const string V_UNIQUE_ID = "V_UNIQUE_ID";
        public const string V_SCORE_MARK = "V_SCORE_MARK";
        public const string V_SCORE_RATE = "V_SCORE_RATE";
    }

}
