namespace Learning_ASPNETCORE.Middleware
{
    public static class UseFirstMiddlewareMethod
    {
        public static void UseFirstMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }

        public static void UseSecondMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
    }
}
