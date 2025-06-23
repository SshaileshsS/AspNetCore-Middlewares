    class PrintMiddleware
    {
        public static Task writeAsync(HttpContext context)
        {
            return context.Response.WriteAsync("Hello World. WELCOMES you xHair.");
        }
    }
