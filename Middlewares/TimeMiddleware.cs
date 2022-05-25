public class TimeMiddleware{
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {
        await next(context); //it calls the following method

        if(context.Request.Query.Any(p => p.Key == "time")) //runs after executing controllers
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
        
    }

}
public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}