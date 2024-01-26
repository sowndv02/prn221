namespace Learning_ASPNETCORE.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        // RequestDelegate ~ async (HttpContext context) =>{}
        public FirstMiddleware(RequestDelegate next) 
        {
            _next = next;
        }
        
        // Được gọi khi HttpContext đi qua Middleware trong pipeline
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(context.Request.Path);

            // await context.Response.WriteAsync(context.Request.Path); // Nếu để nguyên thì khi truyền sang SecondMiddleware sẽ xuất hiện exception
            // Do đó sẽ set nó là nội dung để truyền cho các Middleware phía sau
            context.Items.Add("DataFirstMiddleware", $"<p>{context.Request.Path}</p>"); // Truỳen dưới dạng Dictionary

            // Truyền HttpContext cho các middleware phía sau. Nếu không truyền thì nó sẽ là terminate middleware
            await _next(context);
        }

    }
}
