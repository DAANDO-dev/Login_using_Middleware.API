namespace Routing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            

            //Enable Routing
            app.UseRouting();



            //creating endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("files/{filename}.{extension}", async context =>
                {
                    await context.Response.WriteAsync("In Files");
                });
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
            });

            app.Run();
        }
    }
}
