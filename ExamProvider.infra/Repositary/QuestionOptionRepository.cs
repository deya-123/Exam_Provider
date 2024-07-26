using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using ExamProvider.infra.Mapper;
using ExamProvider.infra.Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamProvider.infra.Repositary
{
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public QuestionOptionRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            SetupMappings();
            _modelContext = modelContext;
        }
        private void SetupMappings()
        {
            PascalCaseMapper<QuestionOptionDTO>.SetTypeMap();
        }

        public async Task CreateOption(CreateQuestionOptionDTO option)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionOptionPackageConstant.V_TITLE, value: option.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionOptionPackageConstant.V_IS_CORRECT, value: option.IsCorrect, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionOptionPackageConstant.V_QUESTION_ID, value: option.QuestionId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.ExecuteAsync(QuestionOptionPackageConstant.QUESTION_OPTION_PACKAGE_CREATE_OPTION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOption(UpdateQuestionOptionDTO option)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionOptionPackageConstant.V_OPTION_ID, value: option.OptionId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: QuestionOptionPackageConstant.V_TITLE, value: option.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionOptionPackageConstant.V_IS_CORRECT, value: option.IsCorrect, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: QuestionOptionPackageConstant.V_QUESTION_ID, value: option.QuestionId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.ExecuteAsync(QuestionOptionPackageConstant.QUESTION_OPTION_PACKAGE_UPDATE_OPTION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteOption(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionOptionPackageConstant.V_OPTION_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.ExecuteAsync(QuestionOptionPackageConstant.QUESTION_OPTION_PACKAGE_DELETE_OPTION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<QuestionOptionDTO>> GetOptionById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: QuestionOptionPackageConstant.V_OPTION_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryAsync<QuestionOptionDTO>(QuestionOptionPackageConstant.QUESTION_OPTION_PACKAGE_GET_OPTION_BY_ID, param, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task<List<QuestionOptionDTO>> GetAllOptions()
        {
            var res = await _dbContext.Connection.QueryAsync<QuestionOptionDTO>(QuestionOptionPackageConstant.QUESTION_OPTION_PACKAGE_GET_ALL_OPTIONS, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task<List<QuestionOptionDTO>> GetAllOptionsByQuestionId(decimal id)
        {
            return await _modelContext.QuestionOptions.Where(e => e.QuestionId == id).Select(e => new QuestionOptionDTO
            {
                CreatedAt = e.CreatedAt,
                Title=e.Title,
                OptionId=e.OptionId,
                IsCorrect=e.IsCorrect
            }).ToListAsync();
        }
    }

}
