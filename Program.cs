namespace SplitWebAPI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(); ////��������� ��������� ������������
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/Swagger/v1/Swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            //app.MapControllerRoute(
            //    name: "user",
            //    pattern: "{controller=User}/{action=NewUser}"); //������������� User-NewUser

            //app.MapControllerRoute(
            //    name: "user",
            //    pattern: "{controller=User}/{action=DeleteAllUsers}"); //������������� User-deleteallusers

            //app.MapControllerRoute(
            //    name: "user",
            //    pattern: "{controller=User}/{action=DeleteUserById}"); //������������� User-deleteUserById

            //app.MapControllerRoute(
            //    name: "expense",
            //    pattern: "{controller=Expense}/{action=NewExpense}"); //������������� User-deleteUserById
            app.MapControllers();

            app.Run();

            //builder.Services.AddDbContext<SplitWebAPIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SplitWebAPIContext")));
        }
    }
}