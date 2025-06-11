using Login_using_Middleware.CustomMiddleware;


namespace Login_using_Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<MyCustomMiddleware>();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");


              // middleware 1
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("From middleware 1\n");
                await next(context); // Call the next middleware in the pipeline
            });

            // middleware 2
            // app.UseMiddleware<MyCustomMiddleware>();
            // app.UseMyCustomMiddleware();
            app.UseHelloCustomMiddleware();


            // middleware 3
            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("From Middleware 3\n");
            });

            
            app.Run(); // This line ensures the application pipeline is properly terminated.
        }
    }
}
