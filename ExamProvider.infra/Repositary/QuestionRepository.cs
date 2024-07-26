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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;
        public QuestionRepository(IDbContext dbContext,ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<QuestionDTO>.SetTypeMap();
        }

        public async Task CreateQuestion(CreateQuestionDTO question)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionPackageConstant.V_QUESTION_LEVEL, value: question.QuestionLevel, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionPackageConstant.V_QUESTION_TYPE, value: question.QuestionType, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionPackageConstant.V_QUESTION_DESCRIPTION, value: question.QuestionDescription, dbType: DbType.String, direction: ParameterDirection.Input);

            param.Add(name: QuestionPackageConstant.V_EXAM_ID, value: question.ExamId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
           
            await _dbContext.Connection.ExecuteAsync(QuestionPackageConstant.QUESTION_PACKAGE_CREATE_QUESTION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateQuestion(UpdateQuestionDTO question)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionPackageConstant.V_QUESTION_ID, value: question.QuestionId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: QuestionPackageConstant.V_QUESTION_LEVEL, value: question.QuestionLevel, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionPackageConstant.V_QUESTION_TYPE, value: question.QuestionType, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionPackageConstant.V_QUESTION_DESCRIPTION, value: question.QuestionDescription, dbType: DbType.String, direction: ParameterDirection.Input);

            param.Add(name: QuestionPackageConstant.V_EXAM_ID, value: question.ExamId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
          
            await _dbContext.Connection.ExecuteAsync(QuestionPackageConstant.QUESTION_PACKAGE_UPDATE_QUESTION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteQuestion(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionPackageConstant.V_QUESTION_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(QuestionPackageConstant.QUESTION_PACKAGE_DELETE_QUESTION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<QuestionDTO>> GetAllQuestions()
        {
            var res = await _dbContext.Connection.QueryAsync<QuestionDTO>(QuestionPackageConstant.QUESTION_PACKAGE_GET_ALL_QUESTIONS, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task<QuestionDTO> GetQuestionById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionPackageConstant.V_QUESTION_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<QuestionDTO>(QuestionPackageConstant.QUESTION_PACKAGE_GET_QUESTION_BY_ID, param, commandType: CommandType.StoredProcedure);

            return res;
        }

        public async Task<List<QuestionDTO>> GetAllQuestionsByExamId(decimal id)
        {
            return await _modelContext.Questions.Where(e => e.ExamId == id).Select(e => new QuestionDTO{
            CreatedAt = e.CreatedAt,
            QuestionId=e.QuestionId,
            QuestionDescription = e.QuestionDescription,
            QuestionType = e.QuestionType,
            QuestionLevel = e.QuestionLevel,
            }).ToListAsync();
        }
    }

}
