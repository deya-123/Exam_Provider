using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class QuestionPackageConstant
    {
        // Stored procedure names
        public const string QUESTION_PACKAGE_CREATE_QUESTION = "QUESTION_PACKAGE.CREATE_QUESTION";
        public const string QUESTION_PACKAGE_UPDATE_QUESTION = "QUESTION_PACKAGE.UPDATE_QUESTION";
        public const string QUESTION_PACKAGE_DELETE_QUESTION = "QUESTION_PACKAGE.delete_question_hard";
        public const string QUESTION_PACKAGE_GET_QUESTION_BY_ID = "QUESTION_PACKAGE.GET_QUESTION_BY_ID";
        public const string QUESTION_PACKAGE_GET_ALL_QUESTIONS = "QUESTION_PACKAGE.GET_ALL_QUESTIONS";

        // Parameter names
        public const string V_QUESTION_ID = "V_QUESTION_ID";
        public const string V_QUESTION_LEVEL = "V_QUESTION_LEVEL";
        public const string V_QUESTION_TYPE = "V_QUESTION_TYPE";
        public const string V_EXAM_ID = "V_EXAM_ID";
        public const string V_QUESTION_DESCRIPTION = "V_QUESTION_DESCRIPTION";
    }

}
