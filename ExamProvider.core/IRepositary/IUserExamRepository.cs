using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface IUserExamRepository
    {
        Task CreateExamUser(CreateUserExamDTO userExam);
        Task UpdateExamUser(UpdateUserExamDTO userExam);
        Task DeleteExamUser(decimal id);
        Task<List<UserExamDTO>> GetAllExamsUser();
        Task<UserExamDTO> GetExamUserById(decimal id);

        Task<List<ExamReservationDTO>> GetAllExamsReservations();
        Task<List<ExamReservationByStudentDTO>> GetAllExamsReservationsByStudentId(decimal id);
    }

}
