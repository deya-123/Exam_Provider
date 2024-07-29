using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Utilities
{
    public static class ExamPackageConstant
    {
        // Stored procedure names
        public const string EXAM_PACKAGE_CREATE_EXAM = "EXAM_PACKAGE.CREATE_EXAM";
        public const string EXAM_PACKAGE_UPDATE_EXAM = "EXAM_PACKAGE.UPDATE_EXAM";
        public const string EXAM_PACKAGE_DELETE_EXAM = "EXAM_PACKAGE.delete_exam_hard";
        public const string EXAM_PACKAGE_GET_EXAM_BY_ID = "EXAM_PACKAGE.GET_EXAM_BY_ID";
        public const string EXAM_PACKAGE_GET_ALL_EXAMS = "EXAM_PACKAGE.GET_ALL_EXAMS";
        public const string EXAM_PACKAGE_SEARCH_BETWEEN_INTERVAL = "EXAM_PACKAGE.SEARCH_BETWEEN_INTERVAL";
        public const string EXAM_PACKAGE_SEARCH_SPECIFIC_DATE = "EXAM_PACKAGE.SEARCH_SPECIFIC_DATE";

        // Parameter names
        public const string V_EXAM_ID = "V_EXAM_ID";
        public const string V_EXAM_NAME = "V_EXAM_NAME";
        public const string V_EXAM_DURATION = "V_EXAM_DURATION";
        public const string V_EXAM_DESCRIPTION = "V_EXAM_DESCRIPTION";
        public const string V_EXAM_PRICE = "V_EXAM_PRICE";
        public const string V_FIRST_DATE = "V_FIRST_DATE";
        public const string V_SECOND_DATE = "V_SECOND_DATE";
        public const string V_SPECIFIC_DATE = "V_SPECIFIC_DATE";
    }

}
