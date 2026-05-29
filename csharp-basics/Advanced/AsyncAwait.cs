// TaskDemo();
// AsyncMethodDemo();
// AwaitDemo();
// AsyncReturnValueDemo();
// TaskStartBehaviorDemo();
// MultipleAwaitDemo();
// TaskWhenAllDemo();
// TaskWhenAnyDemo()
// AsyncMainDemo();
// ExceptionDemo();


// =====================================================
// OVERVIEW
// =====================================================

/*
Async/Await
Purpose:
Perform long running work without blocking thread

Examples:
- HTTP requests
- Database queries
- File I/O
- Network operations

Important:
- Async does NOT make work faster
- Async makes waiting efficient

Python comparison:
Python:
coroutine = GetData()
Creates coroutine object
Does NOT start execution

Need:
await coroutine
or
asyncio.create_task(...)

C#:
Task task = GetDataAsync()
- Task starts immediately
- Task represents work already in progress
*/


// =====================================================
// 1. TASK
// =====================================================

async Task TaskDemo()
{
    Console.WriteLine("Start");
    await Task.Delay(2000);
    Console.WriteLine("End");
}

/*
Task: Represents work that may complete in future

Python comparison:
await asyncio.sleep(2)
          ↓
await Task.Delay(2000)

Task.Delay(): Does NOT block thread

Unlike:
Thread.Sleep()
which blocks thread
*/


// =====================================================
// 2. ASYNC METHOD
// =====================================================

async Task AsyncMethodDemo()
{
    await DownloadDataAsync();
}

/*
async keyword: Allows use of await

Common signatures:
- Task DoWorkAsync()
- Task<int> GetValueAsync()
- Task<string> DownloadTextAsync()

Naming convention:
MethodNameAsync()
*/


// =====================================================
// 3. AWAIT
// =====================================================

async Task AwaitDemo()
{
    Console.WriteLine("Before");
    await Task.Delay(2000);
    Console.WriteLine("After");
}

/*
await:
- Pause current method until task completes
- Method returns control to caller
- Later resumes execution

Execution:
Before
↓
pause
↓
2 seconds
↓
After
*/


// =====================================================
// 4. TASK<T>
// =====================================================

async Task AsyncReturnValueDemo()
{
    int value = await GetNumberAsync();
    Console.WriteLine(value);
}

/*
Task<T>: Represents future value

Examples:
- Task<int>
- Task<string>
- Task<User>

Python comparison:

async def get_number():
    return 42
        ↓
async Task<int> GetNumberAsync() { return 42; }
*/
    

// =====================================================
// 5. TASK START BEHAVIOR
// =====================================================

async Task TaskStartBehaviorDemo()
{
    Task<int> task = GetNumberAsync();

    Console.WriteLine("Task already started");
    int result = await task;
    Console.WriteLine(result);
}

/*
Very important difference from Python

Python:
coroutine = get_number()
Creates coroutine object
Does NOT start execution

Need:
await coroutine
or
asyncio.create_task(...)

C#:
Task<int> task = GetNumberAsync();

Calling an async method typically starts executing the method immediately until it reaches its first await.
Task represents: Work already in progress

Later:
await task;
waits for completion


Python:
Coroutine object
    ↓
Potential future work

C#:
Task object
    ↓
Work already running
*/


// =====================================================
// 6. MULTIPLE AWAITS
// =====================================================

async Task MultipleAwaitDemo()
{
    await Task.Delay(1000);
    Console.WriteLine("Step 1");
    await Task.Delay(1000);
    Console.WriteLine("Step 2");
}

/*
Sequential execution

Timeline:
Wait 1 second
↓
Step 1
↓
Wait 1 second
↓
Step 2

Total: ≈ 2 seconds
*/


// =====================================================
// 7. TASK.WHENALL
// =====================================================

async Task TaskWhenAllDemo()
{
    Task<int> task1 = GetNumberAsync();
    Task<int> task2 = GetNumberAsync();

    int[] results = await Task.WhenAll(task1, task2);

    Console.WriteLine(results[0]);
    Console.WriteLine(results[1]);
}

/*
Run tasks concurrently

Python comparison:
await asyncio.gather(
    task1(),
    task2()
)

C#:
await Task.WhenAll(
    task1,
    task2
)

Both tasks start
↓
Run concurrently
↓
Wait for all

Task.WhenAll(Task<T>...)
returns:
Task<T[]>

Results available as array


Alternative:
await Task.WhenAll(
    task1,
    task2);

int value1 = await task1;
int value2 = await task2;

No additional waiting
Tasks already completed
*/


// =====================================================
// 8. TASK.WHENANY
// =====================================================

async Task TaskWhenAnyDemo()
{
    Task<int> task1 = GetNumberAfterDelayAsync(1000, 1);
    Task<int> task2 = GetNumberAfterDelayAsync(3000, 2);

    Task<int> completedTask = await Task.WhenAny(task1, task2);

    Console.WriteLine(await completedTask);
}

/*
Task.WhenAny()
- Waits for first task to complete

Important: Returns the completed task, NOT its result

Reason: WhenAny answers: "Which task finished first?"

Example:
Task<int> completedTask = await Task.WhenAny(task1, task2);

First await: Find winning task

Second await: Get winner's result
int result = await completedTask;

Compare:
Task.WhenAll()
    ↓
Returns all results

Task.WhenAny()
    ↓
Returns winning task

Common use:
- Race operations
- Use fastest response
*/


// =====================================================
// 9. ASYNC MAIN
// =====================================================

async Task AsyncMainDemo()
{
    await DownloadDataAsync();
    int value = await GetNumberAsync();
    Console.WriteLine(value);
}

/*
Python:
async def main():
    ...

asyncio.run(main())

C#: 
Demo method is not actually Main().
Real entry point would be:
static async Task Main()
{
    ...
}


Modern top level statements:
await DownloadDataAsync();

Difference: Python exposes event loop
C# largely hides it
*/


// =====================================================
// 10. EXCEPTIONS
// =====================================================

async Task ExceptionDemo()
{
    try
    {
        await ThrowErrorAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

/*
Exceptions work normally with async/await

Use:
try/catch

Exception travels through await chain
*/


// =====================================================
// TYPES
// =====================================================

async Task DownloadDataAsync()
{
    await Task.Delay(1000);

    Console.WriteLine("Downloaded");
}


async Task<int> GetNumberAsync()
{
    await Task.Delay(1000);

    return 42;
}


async Task<int> GetNumberAfterDelayAsync(int delay, int value)
{
    await Task.Delay(delay);
    return value;
}


async Task ThrowErrorAsync()
{
    await Task.Delay(1000);
    throw new Exception("Boom");
}

/*
Task
↓
Work running now or completing later

Task<T>
↓
Future value

await
↓
Pause method
↓
Resume when task finishes


Python:
Coroutine object
↓
Not started

C#:
Task object
↓
Already started
*/