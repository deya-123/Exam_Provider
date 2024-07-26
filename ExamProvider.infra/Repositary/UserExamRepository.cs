using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using ExamProvider.infra.Mapper;
using ExamProvider.infra.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Repositary
{
    public class UserExamRepository : IUserExamRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;
        public UserExamRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<UserExamDTO>.SetTypeMap();
        }

        public async Task CreateExamUser(CreateUserExamDTO userExam)
        {
            DynamicParameters param = new();
            param.Add(name: UserExamPackageConstant.V_USER_ID, value: userExam.UserId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_EXAM_ID, value: userExam.ExamId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_UNIQUE_ID, value: userExam.UniqueId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_SCORE_MARK, value: userExam.ScoreMark, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_SCORE_RATE, value: userExam.ScoreRate, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserExamPackageConstant.USER_EXAM_PACKAGE_CREATE_EXAM_USER, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateExamUser(UpdateUserExamDTO userExam)
        {
            DynamicParameters param = new();
            param.Add(name: UserExamPackageConstant.V_USER_EXAM_ID, value: userExam.UserExamId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_USER_ID, value: userExam.UserId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_EXAM_ID, value: userExam.ExamId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_UNIQUE_ID, value: userExam.UniqueId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_SCORE_MARK, value: userExam.ScoreMark, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: UserExamPackageConstant.V_SCORE_RATE, value: userExam.ScoreRate, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserExamPackageConstant.USER_EXAM_PACKAGE_UPDATE_EXAM_USER, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteExamUser(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: UserExamPackageConstant.V_USER_EXAM_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(UserExamPackageConstant.USER_EXAM_PACKAGE_DELETE_EXAM_USER, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<UserExamDTO>> GetAllExamsUser()
        {
            var res = await _dbContext.Connection.QueryAsync<UserExamDTO>(UserExamPackageConstant.USER_EXAM_PACKAGE_GET_ALL_EXAMS_USER, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task<UserExamDTO> GetExamUserById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: UserExamPackageConstant.V_USER_EXAM_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<UserExamDTO>(UserExamPackageConstant.USER_EXAM_PACKAGE_GET_EXAM_USER_BY_ID, param, commandType: CommandType.StoredProcedure);

            return res;
        }

        public async Task<List<ExamReservationDTO>> GetAllExamsReservations()
        {
         return await _modelContext.UserExams.Include(e=>e.Exam).Include(e=>e.User).Select(e => new ExamReservationDTO() { 

             ExamName=e.Exam!=null ? e.Exam.ExamName : "",
             StudentName= e.User != null ? e.User.UserName: "",
             CreatedAt=e.CreatedAt,
             ScoreMark=e.ScoreMark

         
         }).ToListAsync();
        }

        public async Task<List<ExamReservationByStudentDTO>> GetAllExamsReservationsByStudentId(decimal id)
        {
            return await _modelContext.UserExams.Include(e => e.Exam).Where(e=>e.UserId==id).Select(e => new ExamReservationByStudentDTO() {
                ExamName = e.Exam != null ? e.Exam.ExamName : "",
                CreatedAt = e.CreatedAt,
                ScoreMark = e.ScoreMark

            }).ToListAsync();
        }
    }

}
