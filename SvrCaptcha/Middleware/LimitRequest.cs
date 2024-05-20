using System.Collections.Concurrent;


namespace SvrCaptcha.Middleware {

    public static class LimitRequestExtensions {
        public static IApplicationBuilder UseRequestThrottling (this IApplicationBuilder Builder, int ReqLimit, TimeSpan ReqWindow) {
            return Builder.UseMiddleware<LimitRequest>(ReqLimit, ReqWindow);
        }
    }

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LimitRequest {

        private readonly RequestDelegate Next;
        private readonly ConcurrentDictionary<string, long> RequestCounts = new();
        private readonly int RequestLimit;
        private readonly TimeSpan RequestWindow;

        public LimitRequest (RequestDelegate NextD, int ReqLimit, TimeSpan ReqWindow) {
            Next = NextD;
            RequestLimit = ReqLimit;
            RequestWindow = ReqWindow;
        }

        public async Task Invoke (HttpContext Context) {
            string IpAddress = Context.Connection.RemoteIpAddress.ToString();
            long CurrentReqCount = RequestCounts.AddOrUpdate(IpAddress, 1, (_, count) => count + 1);

            if (CurrentReqCount > RequestLimit) {
                Context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await Context.Response.WriteAsync("Too Many Requests");
                return;
            }
            await Next(Context);
            Task.Delay(RequestWindow).ContinueWith(R =>{
                RequestCounts.TryRemove(IpAddress, out _);
            });
        }
    }
}
