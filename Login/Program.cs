using Login.CustomMiddleware;
namespace Login
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //Invoking custom middleware
            app.UseLoginMiddleware();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("No response");
            }); 

            app.Run();
        }
    }
}
