/*
PRIMARY CONSTRUCTORS - THE IMPORTANT PART

Primary constructor parameters are still PARAMETERS.
    public struct Distance(double dx, double dy)

does NOT automatically create:
    private double dx;
    private double dy;

The compiler only creates hidden storage when it is needed.

===============================================================================
CASE 1: PARAMETERS NOT REFERENCED AFTER CONSTRUCTION
===============================================================================

- The parameters are only needed during construction.
- After construction, the object only needs the computed values.

Therefore:
    NO hidden storage is generated for dx and dy.

*/

public struct Distance(double dx, double dy)
{
    // Backing storage IS generated for Magnitude and Direction
    // because they are auto-properties.

    public double Magnitude { get; } = Math.Sqrt(dx * dx + dy * dy);
    public double Direction { get; } = Math.Atan2(dy, dx);
}

/*
Conceptual compiler expansion:

public struct Distance
{
    private readonly double _magnitude;
    private readonly double _direction;

    public double Magnitude => _magnitude;
    public double Direction => _direction;

    public Distance(double dx, double dy)
    {
        _magnitude = Math.Sqrt(dx * dx + dy * dy);
        _direction = Math.Atan2(dy, dx);
    }
}

Memory Layout:
Distance
---------
_magnitude
_direction

NO dx
NO dy

Reason:
dx and dy are only needed while constructing the object.
After construction they are never referenced again.
*/


// ============================================================================
// Traditional equivalent
// ============================================================================

public struct Distance2
{
    public double Magnitude { get; }
    public double Direction { get; }

    public Distance2(double dx, double dy)
    {
        Magnitude = Math.Sqrt(dx * dx + dy * dy);
        Direction = Math.Atan2(dy, dx);
    }
}


/*
===============================================================================
CASE 2: PARAMETERS REFERENCED AFTER CONSTRUCTION
===============================================================================

Now dx and dy are referenced AFTER construction.
The object must remember them.

Therefore:
Hidden storage IS generated.

The compiler creates hidden fields to hold dx and dy.
*/

public struct Distance3(double dx, double dy)
{
    /*
        - Magnitude is a PROPERTY.
        - It does NOT store a value.
        - It recomputes the value every access.
        - Because it uses dx and dy after construction,
          the compiler must store dx and dy somewhere.
    */
    public double Magnitude => Math.Sqrt(dx * dx + dy * dy);

    /*
        Also a PROPERTY.
        No storage of its own.
    */
    public double Direction => Math.Atan2(dy, dx);

    /*
        Uses dx and dy after construction.
        Therefore dx and dy must exist somewhere.
    */
    public void Translate(double deltaX, double deltaY)
    {
        dx += deltaX;
        dy += deltaY;
    }

    public Distance3() : this(0, 0) { }
}


/*
Conceptual compiler expansion:

public struct Distance4
{
    // Hidden compiler-generated fields

    private double __unspeakable_dx;
    private double __unspeakable_dy;

    // PROPERTY
    // No backing storage

    public double Magnitude =>
        Math.Sqrt(
            __unspeakable_dx * __unspeakable_dx +
            __unspeakable_dy * __unspeakable_dy
        );

    // PROPERTY
    // No backing storage

    public double Direction =>
        Math.Atan2(
            __unspeakable_dy,
            __unspeakable_dx
        );

    public void Translate(double deltaX, double deltaY)
    {
        __unspeakable_dx += deltaX;
        __unspeakable_dy += deltaY;
    }

    public Distance4(double dx, double dy)
    {
        __unspeakable_dx = dx;
        __unspeakable_dy = dy;
    }

    public Distance4() : this(0, 0) { }
}

Memory Layout:
Distance4
---------
__unspeakable_dx
__unspeakable_dy

NO Magnitude storage
NO Direction storage

Reason:
- Magnitude and Direction are computed properties.
- Every access needs dx and dy.
- Translate() also modifies dx and dy.
- Therefore the compiler must preserve dx and dy by generating hidden fields.
*/


/*
===============================================================================
RULE OF THUMB
===============================================================================

Ask: "Will this parameter be needed AFTER construction?"

If NO:
    public struct Example(int x)
    {
        public int Square { get; } = x * x;
    }

Result: Hidden storage NOT generated for x.
Reason: x is only used during initialization.

-------------------------------------------------------------------------------

If YES:
    public struct Example(int x)
    {
        public int Square => x * x;
    }

Result: Hidden storage generated for x.
Reason: Every property access needs x.

-------------------------------------------------------------------------------

If YES:

    public struct Example(int x)
    {
        public void Increment()
        {
            x++;
        }
    }

Result: Hidden storage generated for x.
Reason: The method needs x after construction.


-------------------------------------------------------------------------------

MENTAL MODEL

Primary constructor parameters are:
    Constructor parameters
    +
    Wider scope

The compiler decides:
    Needed after construction? -> Generate hidden storage
    Only needed during initialization? -> No hidden storage
*/