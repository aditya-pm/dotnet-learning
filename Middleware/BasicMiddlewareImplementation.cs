List<Func<Action, Action>> middlewares = [];

// Register a middleware
void Use(Func<Action, Action> middleware)
{
    middlewares.Add(middleware);
}


// Build the middleware pipeline
Action BuildPipeline(Action endpoint)
{
    // initially, the pipeline is just the endpoint.
    Action pipeline = endpoint;

    // wrap each middleware around the current pipeline,
    // starting from the LAST middleware.
    for (int i = middlewares.Count - 1; i >= 0; i--)
    {
        pipeline = middlewares[i](pipeline);
    }

    return pipeline;
}


// Middleware 1 - Logging
Use(next =>
{
    return () =>
    {
        Console.WriteLine("Logging BEFORE");
        next();
        Console.WriteLine("Logging AFTER");
    };
});


// Middleware 2 - Authentication
bool authenticated = true;

Use(next =>
{
    return () =>
    {
        Console.WriteLine("Authentication");

        if (!authenticated)
        {
            Console.WriteLine("401 Unauthorized");
            return;
        }

        next();
    };
});


// Middleware 3 - Authorization
bool isAdmin = true;

Use(next =>
{
    return () =>
    {
        Console.WriteLine("Authorization");
        if (!isAdmin)
        {
            Console.WriteLine("403 Forbidden");
            return;
        }
        next();
    };
});

// ==========================================================
// "Routing Middleware"
// ==========================================================
//
// In a REAL web framework, routing would inspect the incoming
// HTTP request and decide which endpoint to execute.
//
// GET /products  -> ProductsEndpoint
// GET /orders    -> OrdersEndpoint
// POST /login    -> LoginEndpoint
//
// Here we simply pretend routing already chose one endpoint.
//

Action endpoint = () =>
{
    Console.WriteLine("Products Endpoint");
};


// Build and execute pipeline
Action pipeline = BuildPipeline(endpoint);

Console.WriteLine("=== Request Started ===");

pipeline();

Console.WriteLine("=== Request Finished ===");