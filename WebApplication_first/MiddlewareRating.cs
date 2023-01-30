using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace WebApplication_first
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareRating
    {
        private readonly RequestDelegate _next;

        public MiddlewareRating(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IConfiguration config)
        {

          
            string METHOD = httpContext.Request.Method;
            string HOST = httpContext.Request.Host.ToString();
          
            string PATH = httpContext.Request.Path;
            string Referer = httpContext.Request.RouteValues.ToString();
            string UserAgent = httpContext.Request.Headers.UserAgent.ToString();
            string ConnectionString = config.GetConnectionString("school");
            //DateTime Record_Dat = DateTime.Now;
            string query = "INSERT INTO RATING(HOST, METHOD, PATH,Referer,UserAgent) VALUES(@HOST,@METHOD,@PATH,@Referer,@UserAgent)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
               

                    sqlCommand.Parameters.Add("@METHOD", SqlDbType.NChar);
                sqlCommand.Parameters["@METHOD"].Value = METHOD;

                sqlCommand.Parameters.Add("@HOST", SqlDbType.NChar);
                sqlCommand.Parameters["@HOST"].Value = HOST;


                sqlCommand.Parameters.Add("@PATH", SqlDbType.NChar);
                sqlCommand.Parameters["@PATH"].Value = PATH;

                sqlCommand.Parameters.Add("@Referer", SqlDbType.NChar);
                sqlCommand.Parameters["@Referer"].Value = PATH;

                sqlCommand.Parameters.Add("@UserAgent", SqlDbType.NChar);
                sqlCommand.Parameters["@UserAgent"].Value = PATH;
                //
                //sqlCommand.Parameters.Add("@Record_Date", SqlDbType.NChar);
                //sqlCommand.Parameters["@Record_Date"].Value = Record_Date;

                sqlConnection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                
            }
            //
            return _next(httpContext);
        }
    }


// Extension method used to add the middleware to the HTTP request pipeline.
public static class MiddlewareRatingExtensions
    {
        public static IApplicationBuilder UseMiddlewareRating(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareRating>();
        }
    }
}
