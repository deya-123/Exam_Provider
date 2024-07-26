using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IQuestionService
    {
        Task CreateQuestion(CreateQuestionDTO question);
        Task UpdateQuestion(UpdateQuestionDTO question);
        Task DeleteQuestion(decimal id);
        Task<List<QuestionDTO>> GetAllQuestions();
        Task<QuestionDTO> GetQuestionById(decimal id);
        Task<List<QuestionDTO>> GetAllQuestionsByExamId(decimal id);
    }

}
