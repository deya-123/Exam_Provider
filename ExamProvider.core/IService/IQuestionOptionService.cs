using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IQuestionOptionService
    {

        Task CreateOption(CreateQuestionOptionDTO option);
        Task UpdateOption(UpdateQuestionOptionDTO option);
        Task DeleteOption(decimal id);
        Task<QuestionOptionDTO> GetOptionById(decimal  id);
        Task<List<QuestionOptionDTO>> GetAllOptions();
        Task<List<QuestionOptionDTO>> GetAllOptionsByQuestionId(decimal id);
    }
}
