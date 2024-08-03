using Dapper;
using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using ExamProvider.infra.Common;
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
    public class ExamRepository : IExamRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;
        public ExamRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<ExamDTO>.SetTypeMap();
        }

        public async Task CreateExam(CreateExamDTO exam)
        {
            DynamicParameters param = new();
            param.Add(name: ExamPackageConstant.V_EXAM_NAME, value: exam.ExamName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamPackageConstant.V_EXAM_DURATION, value: exam.ExamDuration, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: ExamPackageConstant.V_EXAM_DESCRIPTION, value: exam.ExamDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamPackageConstant.V_EXAM_PRICE, value: exam.Price, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(ExamPackageConstant.EXAM_PACKAGE_CREATE_EXAM, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateExam(UpdateExamDTO exam)
        {
            DynamicParameters param = new();
            param.Add(name: ExamPackageConstant.V_EXAM_ID, value: exam.ExamId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: ExamPackageConstant.V_EXAM_NAME, value: exam.ExamName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamPackageConstant.V_EXAM_DURATION, value: exam.ExamDuration, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: ExamPackageConstant.V_EXAM_DESCRIPTION, value: exam.ExamDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamPackageConstant.V_EXAM_PRICE, value: exam.Price, dbType: DbType.String, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(ExamPackageConstant.EXAM_PACKAGE_UPDATE_EXAM, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteExam(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: ExamPackageConstant.V_EXAM_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(ExamPackageConstant.EXAM_PACKAGE_DELETE_EXAM, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ExamDTO>> GetAllExams()
        {
            return await _modelContext.Exams
              .Select(e => new ExamDTO()
              {
                  ExamDuration = e.ExamDuration,
                  ExamName = e.ExamName,
                  ExamDescription = e.ExamDescription,
                  ExamId = e.ExamId,
                  Price = e.Price,
                  DeletedAt = e.DeletedAt

              })
              .ToListAsync();
        }

        public async Task<ExamDTO> GetExamByName(string examName)
        {
            var exam = await _modelContext.Exams.Where(e => e.ExamName != null && e.ExamName.ToLower() == examName.ToLower()) 
                .Select(e => new ExamDTO()
                {
                    ExamId = e.ExamId,
                    ExamName = e.ExamName,
                    ExamDescription = e.ExamDescription,
                    ExamDuration = e.ExamDuration,
                    Price=e.Price
             
                }).FirstOrDefaultAsync();
            if (exam is null) {
                throw new Exception("exam is null");
            }
            return exam;
        }
        public async Task<List<Exam>> GetExamsByName(string examName)
        {
            var exam = await _modelContext.Exams.Include(e=>e.Questions)
                .ThenInclude(e=>e.QuestionOptions)
                .Where(e => e.ExamName == examName).ToListAsync();
                //.Select(e => new ExamDTO()
                //{
                //    ExamId = e.ExamId,
                //    ExamName = e.ExamName,
                //    ExamDescription = e.ExamDescription,
                //    ExamDuration = e.ExamDuration,
                //    CreatedAt = e.CreatedAt,
                //}).FirstOrDefaultAsync();
            if (exam is null)
            {
                throw new Exception("");
            }
            return exam;
        }

        public async Task<List<ExamDetailsWithoutAnwersDTO>> GetExamDetailsWithoutAnwersByName(string examName)
        {

            var exam = await _modelContext.Exams
                .Include(e => e.Questions)
                .ThenInclude(e => e.QuestionOptions)
                .Where(e => e.ExamName == examName)
                .Select(e => new ExamDetailsWithoutAnwersDTO {
                    ExamDescription = e.ExamDescription,
                    ExamDuration = e.ExamDuration,
                    ExamName = e.ExamName,
                    Questions = e.Questions.Select(q => new QuestionWithoutAnswerDTO {
                        QuestionDescription = q.QuestionDescription,
                        QuestionLevel = q.QuestionLevel,
                        QuestionId = q.QuestionId,
                        ExamId = q.ExamId,
                        Options = q.QuestionOptions.Select(e => new OptionWithoutAnswerDTO {
                            Title = e.Title,
                            OptionId = e.OptionId
                        })

                    })

                }).ToListAsync();
       
            if (exam is null)
            {
                throw new Exception("");
            }
            return exam;
        }




        public async Task<ExamDTO> GetExamById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: ExamPackageConstant.V_EXAM_ID, value: id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<ExamDTO>(ExamPackageConstant.EXAM_PACKAGE_GET_EXAM_BY_ID, param, commandType: CommandType.StoredProcedure);

            return res;
        }

        public async Task<List<ExamDTO>> SearchBetweenInterval(DateTime? startDate, DateTime? endDate)
        {
            IQueryable<Exam> query = _modelContext.Exams;


            if (startDate != null)
            {
                query = query.Where(r => r.CreatedAt >= startDate);
            }
            if (endDate != null)
            {
                query = query.Where(r => r.CreatedAt <= endDate);
            }

            return await query.Select(e=>new ExamDTO() { 
          ExamId=e.ExamId,
          ExamName=e.ExamName,
          ExamDescription=e.ExamDescription,
          ExamDuration=e.ExamDuration,  
          CreatedAt=e.CreatedAt,
          })
          .ToListAsync();
          
        }

        public async Task<List<ExamDTO>> SearchSpecificDate(DateTime specificDate)
        {
            DynamicParameters param = new();
            param.Add(name: ExamPackageConstant.V_SPECIFIC_DATE, value: specificDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var res = await _dbContext.Connection.QueryAsync<ExamDTO>(ExamPackageConstant.EXAM_PACKAGE_SEARCH_SPECIFIC_DATE, param, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task UpdateState(decimal id, string state)
        {
           var exam= await _modelContext.Exams.FirstOrDefaultAsync(e => e.ExamId == id);

            if (exam is null) {

                throw new Exception("exam is not found");

            }

            if (state == "active")
            {
                exam.DeletedAt =null;

            }
            else {

                exam.DeletedAt=DateTime.Now;
            }

            await _modelContext.SaveChangesAsync();
        }

        public async Task<List<ExamDTO>> GetAllActiveExams()
        {
          return await _modelContext.Exams.Where(e=>e.DeletedAt==null)
                .Select(e=>new ExamDTO() {
                    ExamDuration=e.ExamDuration,
                    ExamName=e.ExamName,
                    ExamDescription=e.ExamDescription,
                    ExamId=e.ExamId,
                    Price=e.Price,
                    DeletedAt=e.DeletedAt
                   
                })
                .ToListAsync();
        }
    }

}
