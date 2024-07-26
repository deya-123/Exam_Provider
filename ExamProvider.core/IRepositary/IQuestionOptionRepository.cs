using ExamProvider.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProvider.core.DTO;
namespace ExamProvider.core.IRepositary
{
    public interface IQuestionOptionRepository
    {
        Task CreateOption(CreateQuestionOptionDTO option);
        Task UpdateOption(UpdateQuestionOptionDTO option);
        Task DeleteOption(decimal id);
        Task<List<QuestionOptionDTO>> GetOptionById(decimal id);
        Task<List<QuestionOptionDTO>> GetAllOptions();
        Task<List<QuestionOptionDTO>> GetAllOptionsByQuestionId(decimal id);
    }

}
