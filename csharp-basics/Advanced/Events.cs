// BasicEventDemo();
// MultipleSubscribersDemo();
// EventHandlerDemo();
// CustomEventDataDemo();
// SubscribeUnsubscribeDemo();
// DelegateVsEventDemo();


// =====================================================
// 1. BASIC EVENT
// =====================================================

void BasicEventDemo()
{
    Button button = new();
    button.Click += OnButtonClicked;
    button.RaiseClick();
}

/*
Events are built on delegates

Delegate:
- Stores methods
- Can invoke methods

Event:
- Stores subscribers
- Restricts invocation


Why events exist?

Suppose:
public Action? Click;

Outside code can:
- Subscribe: Click += Handler;
- Unsubscribe: Click -= Handler;
- Invoke delegate: Click?.Invoke();
- Replace delegate: Click = Handler;

Problem:
Outside code can trigger behavior that should belong to object itself

Example:
button.Click?.Invoke();

Someone can pretend button was clicked
Event fixes this

public event Action? Click;

Outside code can only:
- Subscribe
- Unsubscribe

Outside code cannot:
- Click?.Invoke();
- Click();
- Click = Handler;

Only Button can raise event
*/


// =====================================================
// 2. MULTIPLE SUBSCRIBERS
// =====================================================

void MultipleSubscribersDemo()
{
    Button button = new();

    button.Click += Handler1;
    button.Click += Handler2;

    button.RaiseClick();
}

/*
Events support: Multiple subscribers

+= Subscribe
-= Unsubscribe

All subscribers invoked in order
*/


// =====================================================
// INVOKE
// =====================================================

/*
Invoke(): Delegate method

Example: Action hello = SayHello;

These are equivalent:
hello();
hello.Invoke();

Difference:
hello?.Invoke();
is valid

hello?.();
does not exist

Because Invoke() is a method, it works with ?. syntax


Therefore events are usually raised as:
SomeEvent?.Invoke();

Combines:
1. Null check
2. Delegate invocation
into one statement
*/


// =====================================================
// 3. EVENTHANDLER
// =====================================================

void EventHandlerDemo()
{
    Button2 button = new();
    button.Click += Button_Click;
    button.RaiseClick();
}

/*
EventHandler: Built-in delegate provided by .NET

Signature:
void Handler(object? sender, EventArgs e)

Equivalent idea:
delegate void EventHandler(object? sender, EventArgs e);
- sender: Object that raised the event
- Useful when one handler is subscribed to multiple publishers


Example:
button1.Click += Button_Click;
button2.Click += Button_Click;

Inside handler:
if (sender == button1)
{
    ...
}
if (sender == button2)
{
    ...
}


EventArgs:
Contains additional event data
EventArgs.Empty means: "No data to send"

For custom data:
Create class derived from EventArgs and use:
EventHandler<TEventArgs>

Example:
EventHandler<PriceChangedEventArgs>


Most common event type in .NET


sender
↓
Who triggered event?

EventArgs
↓
What information came
with the event?
*/


// =====================================================
// 4. CUSTOM EVENT DATA
// =====================================================

void CustomEventDataDemo()
{
    Stock stock = new();

    stock.PriceChanged += Stock_PriceChanged;

    stock.ChangePrice(100, 150);
}

/*
EventArgs: Used to pass data to subscribers

Create custom class derived from EventArgs
*/


// =====================================================
// 5. SUBSCRIBE / UNSUBSCRIBE
// =====================================================

void SubscribeUnsubscribeDemo()
{
    Button button = new();
    button.Click += Handler1;
    button.RaiseClick();

    Console.WriteLine();

    button.Click -= Handler1;
    button.RaiseClick();
}

/*
+= Subscribe
-= Unsubscribe

Important: Avoid memory leaks in long running apps
*/


// =====================================================
// 6. DELEGATE VS EVENT
// =====================================================

void DelegateVsEventDemo()
{
    Publisher publisher = new();
    publisher.Notify += Handler1;
    publisher.RaiseNotify();
}

/*
Delegate: Stores methods
Anyone with access can:
- Invoke
- Replace
- Clear
- Subscribe

Event: Restricted delegate

Outside code can:
- Subscribe
- Unsubscribe

Outside code cannot:
- Invoke
- Replace
- Clear

Only owner class can raise event


Delegate
↓
Stores methods
↓
Anyone can invoke

Event
↓
Stores subscribers
↓
Only owner can invoke


Publisher / Subscriber pattern:
Publisher
↓
Raises event
↓
Subscribers notified
Subscribers cannot raise publisher's event
*/


// =====================================================
// TYPES
// =====================================================

void OnButtonClicked()
{
    Console.WriteLine("Button clicked");
}


void Handler1()
{
    Console.WriteLine("Handler 1");
}


void Handler2()
{
    Console.WriteLine("Handler 2");
}


void Button_Click(object? sender, EventArgs e)
{
    Console.WriteLine("Button clicked");
}


void Stock_PriceChanged(object? sender, PriceChangedEventArgs e)
{
    Console.WriteLine($"Old price: {e.OldPrice}, New price: {e.NewPrice}");
}


class Button
{
    public event Action? Click;

    public void RaiseClick()
    {
        Click?.Invoke();
    }
}

/*
?. operator: Null conditional operator

Meaning: "If not null, invoke"
Otherwise: Do nothing

Equivalent:
if (Click != null)
{
    Click.Invoke();
}


Why needed?
Initially:
Click == null
No subscribers exist

Calling: Click();
would throw: NullReferenceException
*/


class Button2
{
    public event EventHandler? Click;

    public void RaiseClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}


class PriceChangedEventArgs: EventArgs
{
    public decimal OldPrice
    {
        get;
    }

    public decimal NewPrice
    {
        get;
    }

    public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
    {
        OldPrice = oldPrice;
        NewPrice = newPrice;
    }
}


class Stock
{
    public event EventHandler<PriceChangedEventArgs>? PriceChanged;

    public void ChangePrice(decimal oldPrice, decimal newPrice)
    {
        PriceChanged?.Invoke(this, new PriceChangedEventArgs(oldPrice, newPrice));
    }
}


class Publisher
{
    public event Action? Notify;

    public void RaiseNotify()
    {
        Notify?.Invoke();
    }
}