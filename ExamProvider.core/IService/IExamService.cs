using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IExamService
    {
        Task<List<ExamDTO>> GetAllExams();
        Task<ExamDTO> GetExamById(decimal id);
        Task CreateExam(CreateExamDTO exam);
        Task UpdateExam(UpdateExamDTO exam);
        Task DeleteExam(decimal id);
        Task<List<ExamDTO>> SearchBetweenInterval(DateTime? firstDate, DateTime? secondDate);
        Task<List<ExamDTO>> SearchSpecificDate(DateTime specificDate);
        Task<List<Exam>> GetExamsByName(string examName);
        Task<ExamDTO> GetExamByName(string examName);
        Task<List<ExamDetailsWithoutAnwersDTO>> GetExamDetailsWithoutAnwersByName(string examName);
    }
}
