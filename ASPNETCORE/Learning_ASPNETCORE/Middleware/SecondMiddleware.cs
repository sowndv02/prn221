namespace Learning_ASPNETCORE.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        /*
         Url: "/xxx.html"
            - Không gọi middleware phía sau
            - Response: Bạn không được truy cập
            - Header - SecondMiddleware: Bạn không được truy cập
        Url: != "xxx.html" 
            - Header - SecondMiddleware: Bạn được truy cập
            - Chuyển HttpContext cho middleware phía sau 
         */
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if(context.Request.Path == "xxx.html")
            {
                // Phải thiết lập header trước nội dung response 
                context.Response.Headers.Add("SecondeMiddleware", "Bạn không được truy cập");

                // Get data của FirtMiddleware
                var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (dataFromFirstMiddleware != null)
                    await context.Response.WriteAsync((string)dataFromFirstMiddleware);
                
                await context.Response.WriteAsync("Bạn không được truy cập");
            }
            else
            {
                context.Response.Headers.Add("SecondeMiddleware", "Bạn được truy cập");
                await next(context);
            }
        }
    }
}
