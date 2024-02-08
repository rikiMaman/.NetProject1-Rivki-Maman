using Newtonsoft.Json;

namespace WeightWatchers.Config
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _looger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> looger)
        {
            this.next = next;
            _looger = looger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm");

                _looger.LogDebug($"start cell api {context.Request.Path} start in {time} ");
                ///שורה הכי חשובה שגורמת להמשך במקרה ולא רוצים שימשיך אנחנו לא לקרוא לURV VZU 
                await next(context);

                string time2 = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm");

                _looger.LogInformation($"end  cell api {context.Request.Path} start in {time2} ");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //ממיר את השגיאה לJSON ומחזיר מכל הפונקציות במקרה ונפל 

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            //context.Response.ContentType = "application/json";            
            return context.Response.WriteAsync(result);
        }
    }
}
