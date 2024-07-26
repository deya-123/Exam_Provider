using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class QuestionOptionPackageConstant
    {
        // Stored procedure names
        public const string QUESTION_OPTION_PACKAGE_CREATE_OPTION = "QUESTION_OPTION_PACKAGE.create_question_option";
        public const string QUESTION_OPTION_PACKAGE_UPDATE_OPTION = "QUESTION_OPTION_PACKAGE.update_question_option";
        public const string QUESTION_OPTION_PACKAGE_DELETE_OPTION = "QUESTION_OPTION_PACKAGE.delete_question_option_hard";
        public const string QUESTION_OPTION_PACKAGE_GET_OPTION_BY_ID = "QUESTION_OPTION_PACKAGE.get_question_option_by_id";
        public const string QUESTION_OPTION_PACKAGE_GET_ALL_OPTIONS = "QUESTION_OPTION_PACKAGE.get_all_question_options";

        // Parameter names
        public const string V_OPTION_ID = "V_OPTION_ID";
        public const string V_TITLE = "V_TITLE";
        public const string V_IS_CORRECT = "V_IS_CORRECT";
        public const string V_QUESTION_ID = "V_QUESTION_ID";
    }

}
