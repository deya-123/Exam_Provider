using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class ExamService : IExamService
    {
 


        private readonly IExamRepository _examRepositary;

        public ExamService(IExamRepository examRepositary)
        {
            _examRepositary = examRepositary;
        }

        public async Task CreateExam(CreateExamDTO exam)
        {
            await _examRepositary.CreateExam(exam);
        }

        public async Task DeleteExam(decimal id)
        {
            await _examRepositary.DeleteExam(id);
        }

        public async Task<List<ExamDTO>> GetAllActiveExams()
        {
            return await _examRepositary.GetAllActiveExams();
        }

        public async Task<List<ExamDTO>> GetAllExams()
        {
           return await _examRepositary.GetAllExams();
        }

        public async Task<ExamDTO> GetExamById(decimal id)
        {
           return await _examRepositary.GetExamById(id);
        }

        public async Task<ExamDTO> GetExamByName(string examName)
        {
            return await _examRepositary.GetExamByName(examName);
        }

        public async Task<List<ExamDetailsWithoutAnwersDTO>> GetExamDetailsWithoutAnwersByName(string examName)
        {
            return await _examRepositary.GetExamDetailsWithoutAnwersByName(examName);
        }

        public async Task<List<Exam>> GetExamsByName(string examName)
        {
            return await _examRepositary.GetExamsByName(examName);
        }

        public async Task<List<ExamDTO>> SearchBetweenInterval(DateTime? firstDate, DateTime? secondDate)
        {
            return await _examRepositary.SearchBetweenInterval(firstDate, secondDate);
        }

        public Task<List<ExamDTO>> SearchSpecificDate(DateTime specificDate)
        {
            throw new NotImplementedException();
        }

        public  async Task UpdateExam(UpdateExamDTO exam)
        {
            await _examRepositary.UpdateExam(exam);
        }

        public async Task UpdateState(decimal id, string state)
        {
            await _examRepositary.UpdateState(id,state);
        }
    }
    
}
