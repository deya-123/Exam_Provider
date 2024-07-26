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
    public class UserExamService : IUserExamService
    {
        private readonly IUserExamRepository _examUserRepositary;

        public UserExamService(IUserExamRepository examUserRepositary)
        {
            _examUserRepositary = examUserRepositary;
        }

        public async Task CreateExamUser(CreateUserExamDTO userExam)
        {
            await _examUserRepositary.CreateExamUser(userExam);
        }

        public async Task DeleteExamUser(decimal id)
        {
            await _examUserRepositary.DeleteExamUser(id);
        }

        public async Task<List<ExamReservationDTO>> GetAllExamsReservations()
        {
            return await _examUserRepositary.GetAllExamsReservations();
        }

        public async Task<List<ExamReservationByStudentDTO>> GetAllExamsReservationsByStudentId(decimal id)
        {
            return await _examUserRepositary.GetAllExamsReservationsByStudentId(id);
        }

        public async Task<List<UserExamDTO>> GetAllExamsUser()
        {
          return  await _examUserRepositary.GetAllExamsUser();
        }

        public async Task<UserExamDTO> GetExamUserById(decimal id)
        {
           return  await _examUserRepositary.GetExamUserById(id);
        }

        public async Task UpdateExamUser(UpdateUserExamDTO userExam)
        {
            await _examUserRepositary.UpdateExamUser(userExam);
        }
    }
}
