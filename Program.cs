namespace SplitWebAPI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(); ////ДОБАВЛЯЕМ ПОДДЕРЖКУ КОНТРОЛЛЕРОВ
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
            //    pattern: "{controller=User}/{action=NewUser}"); //Маршрутизация User-NewUser

            //app.MapControllerRoute(
            //    name: "user",
            //    pattern: "{controller=User}/{action=DeleteAllUsers}"); //Маршрутизация User-deleteallusers

            //app.MapControllerRoute(
            //    name: "user",
            //    pattern: "{controller=User}/{action=DeleteUserById}"); //Маршрутизация User-deleteUserById

            //app.MapControllerRoute(
            //    name: "expense",
            //    pattern: "{controller=Expense}/{action=NewExpense}"); //Маршрутизация User-deleteUserById
            app.MapControllers();

            app.Run();

            //builder.Services.AddDbContext<SplitWebAPIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SplitWebAPIContext")));
        }
    }
}