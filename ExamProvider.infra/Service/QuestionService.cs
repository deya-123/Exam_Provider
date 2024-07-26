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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepositary;

        public QuestionService(IQuestionRepository questionRepositary)
        {
            _questionRepositary = questionRepositary;
        }

        public async Task CreateQuestion(CreateQuestionDTO question)
        {
            await _questionRepositary.CreateQuestion(question);
        }

        public async Task DeleteQuestion(decimal id)
        {
           await _questionRepositary.DeleteQuestion(id);
        }

        public async Task<List<QuestionDTO>> GetAllQuestions()
        {
          return  await _questionRepositary.GetAllQuestions();
        }

        public async Task<List<QuestionDTO>> GetAllQuestionsByExamId(decimal id)
        {
            return await _questionRepositary.GetAllQuestionsByExamId(id);
        }

        public async Task<QuestionDTO> GetQuestionById(decimal id)
        {
            return await _questionRepositary.GetQuestionById(id);
        }

        public async Task UpdateQuestion(UpdateQuestionDTO question)
        {
             await _questionRepositary.UpdateQuestion(question);
        }
    }
}
