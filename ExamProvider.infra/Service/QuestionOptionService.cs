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
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IQuestionOptionRepository _examOptionRepositary;
 
        public QuestionOptionService(IQuestionOptionRepository examOptionRepositary)
        {
            _examOptionRepositary = examOptionRepositary;
        }

        public async Task CreateOption(CreateQuestionOptionDTO option)
        {
          await  _examOptionRepositary.CreateOption(option);
        }

        public async Task DeleteOption(decimal id)
        {
            await _examOptionRepositary.DeleteOption(id);
        }

        public async Task<List<QuestionOptionDTO>> GetAllOptions()
        {
            return await _examOptionRepositary.GetAllOptions();
        }

        public async Task<List<QuestionOptionDTO>> GetAllOptionsByQuestionId(decimal id)
        {
            return await _examOptionRepositary.GetAllOptionsByQuestionId(id);
        }

        public async Task<QuestionOptionDTO> GetOptionById(decimal id)
        {
            return (await _examOptionRepositary.GetOptionById(id)).FirstOrDefault();
        }

        public async Task UpdateOption(UpdateQuestionOptionDTO option)
        {
            await _examOptionRepositary.UpdateOption(option);
        }
    }
}
