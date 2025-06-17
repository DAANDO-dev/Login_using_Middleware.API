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
                   string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
                   
                   string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
                    

                    await context.Response.WriteAsync($"In Files - {fileName} - {extension}");
                });


                // EG : employee/profile/JohnDoe
                endpoints.Map("employee/profile/{EmployeeName?}", async context =>
                {
                    if (context.Request.RouteValues.ContainsKey("EmployeeName"))
                    {
                        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
                        await context.Response.WriteAsync($"In Employee profile - {employeeName}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("In Employee profile - No Employee Name provided");
                    }
                   
                });

                // EG : produtcs/details/1

                endpoints.Map("products/details/{id?}", async context => {
                    if (context.Request.RouteValues.ContainsKey("id"))
                    {
                        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
                        await context.Response.WriteAsync($"Products details - {id}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("Products details - No ID provided");
                    }
                    
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
