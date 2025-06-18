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
                endpoints.Map("employee/profile/{EmployeeName:length(3, 7)=Daki}", async context =>
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
                // EG: daily-report/{reportdate}

                endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
                {
                    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
                    await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");
                });

                // EG: cities/cityID

                endpoints.Map("cities/{cityid:guid}",async context =>
                {
                    Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
                    await context.Response.WriteAsync($"City information - {cityId}");
                });

                //sales-report/2030/apr
                endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
                {
                    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
                    string? month = Convert.ToString(context.Request.RouteValues["month"]);
                    await context.Response.WriteAsync($"Sales report - {year} - {month}");
                });

            });

            
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"No Route matched at  {context.Request.Path}");
            });

            app.Run();
        }
    }
}
