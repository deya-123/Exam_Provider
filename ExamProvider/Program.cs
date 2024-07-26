using ExamProvider.core.Data;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using ExamProvider.infra.Common;
using ExamProvider.infra.Repositary;
using ExamProvider.infra.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using DbContext = ExamProvider.infra.Common.DbContext;

namespace ExamProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDbContext, DbContext>();
            builder.Services.AddScoped<IExamRepository,ExamRepository >();
            builder.Services.AddScoped<IExamService,ExamService >();
            builder.Services.AddScoped<IQuestionOptionRepository,QuestionOptionRepository >();
            builder.Services.AddScoped<IQuestionOptionService,QuestionOptionService >();
            builder.Services.AddScoped<IQuestionRepository,QuestionRepository >();
            builder.Services.AddScoped<IQuestionService,QuestionService >();
            builder.Services.AddScoped<IUserExamRepository,UserExamRepository >();
            builder.Services.AddScoped<IUserExamService,UserExamService >();
            builder.Services.AddScoped<IApiInfoRepository, ApiInfoRepository>();
            builder.Services.AddScoped<IApiInfoService, ApiInfoService>();
            builder.Services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
            builder.Services.AddScoped<ICompanyInfoService, CompanyInfoService>();
            builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();
            builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            builder.Services.AddScoped<IUserInfoService, UserInfoService>();


            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();


            builder.Services.AddDbContext<ModelContext>(x =>
          x.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions => {
                apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
