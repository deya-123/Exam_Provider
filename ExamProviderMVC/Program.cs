using System.Text.Json.Serialization;
using System;
//using ExamProvider.core.ICommon;
//using ExamProvider.core.IRepositary;
//using ExamProvider.core.IService;
//using ExamProvider.infra.Repositary;
//using ExamProvider.infra.Service;
//using ExamProvider.infra.Common;

namespace ExamProviderMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
         
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddScoped<IDbContext, DbContext>();
            //builder.Services.AddScoped<IExamRepository, ExamRepository>();
            //builder.Services.AddScoped<IExamService, ExamService>();
            //builder.Services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
            //builder.Services.AddScoped<IQuestionOptionService, QuestionOptionService>();
            //builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            //builder.Services.AddScoped<IQuestionService, QuestionService>();
            //builder.Services.AddScoped<IUserExamRepository, UserExamRepository>();
            //builder.Services.AddScoped<IUserExamService, UserExamService>();
            //builder.Services.AddScoped<IApiInfoRepository, ApiInfoRepository>();
            //builder.Services.AddScoped<IApiInfoService, ApiInfoService>();
            //builder.Services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
            //builder.Services.AddScoped<ICompanyInfoService, CompanyInfoService>();
            //builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            //builder.Services.AddScoped<IUserRoleService, UserRoleService>();
            //builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            //builder.Services.AddScoped<IUserInfoService, UserInfoService>();
            builder.Services.AddHttpClient();
            builder.Services.AddMvc().AddNToastNotifyNoty();
            builder.Services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required.");
            }).AddViewOptions(options =>
{
options.HtmlHelperOptions.ClientValidationEnabled = true; // Ensure client validation is enabled
});
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            // Add services to the container.
          
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNToastNotify();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}");

            app.Run();

      
        }
    }
}