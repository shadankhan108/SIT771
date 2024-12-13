using SplashKitSDK;

// Base abstract class Robot
public abstract class Robot
{
    // Auto-implemented properties
    public double X { get; private set; }
    public double Y { get; private set; }
    public Color MainColor { get; private set; }
    public Circle CollisionCircle { get; private set; }
    private Vector2D Velocity { get; set; }

    // Property for Width
    public int Width
    {
        get
        {
            return 50;
        }
    }

    // Read-only property for Height
    public int Height
    {
        get
        {
            return 50;
        }
    }

    // Constructor to initialize a Robot object
    public Robot(Window gameWindow, Player player)
    {
        const int SPEED = 4;

        // Randomly initialize X and Y positions
        X = SplashKit.Rnd(gameWindow.Width);
        Y = SplashKit.Rnd(gameWindow.Height);

        // Determine the starting position of the robot (offscreen horizontally or vertically)
        if (SplashKit.Rnd() < 0.5)
        {
            // Offscreen vertically
            X = SplashKit.Rnd(gameWindow.Width);
            Y = SplashKit.Rnd() < 0.5 ? -Height : gameWindow.Height;
        }
        else
        {
            // Offscreen horizontally
            Y = SplashKit.Rnd(gameWindow.Height);
            X = SplashKit.Rnd() < 0.5 ? -Width : gameWindow.Width;
        }

        // Calculate direction towards the player
        Point2D fromPoint = new Point2D { X = X, Y = Y };
        Point2D toPoint = new Point2D { X = player.X, Y = player.Y };

        // Assign a random color
        MainColor = Color.RandomRGB(200);

        // Calculate velocity
        Vector2D direction = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPoint, toPoint));
        Velocity = SplashKit.VectorMultiply(direction, SPEED);
    }

    // Update method to move the robot
    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;

        double centerX = X + Width / 2;
        double centerY = Y + Height / 2;
        CollisionCircle = SplashKit.CircleAt(centerX, centerY, 20);
    }

    // Check if the robot is offscreen
    public bool IsOffscreen(Window screen)
    {
        return X < -Width || X > screen.Width || Y < -Height || Y > screen.Height;
    }

    // Abstract draw method to be implemented by subclasses
    public abstract void Draw();
}

// Subclass Boxy
public class Boxy : Robot
{
    public Boxy(Window gameWindow, Player player) : base(gameWindow, player) { }

    public override void Draw()
    {
        double centerX = X + Width / 2;
        double centerY = Y + Height / 2;
        double eyeY = Y + 10;
        double mouthY = Y + 30;

        // Draw a triangle for the body
        Point2D[] triangle = new Point2D[]
        {
            new Point2D { X = centerX, Y = centerY - 30 },
            new Point2D { X = centerX - 30, Y = centerY + 30 },
            new Point2D { X = centerX + 30, Y = centerY + 30 }
        };

        for (int i = 0; i < triangle.Length; i++)
        {
            Point2D start = triangle[i];
            Point2D end = triangle[(i + 1) % triangle.Length];
            SplashKit.DrawLine(Color.Gray, start, end);
        }

        // Draw eyes and mouth
        SplashKit.FillRectangle(Color.Red, centerX - 15, eyeY, 10, 10);
        SplashKit.FillRectangle(Color.Red, centerX + 5, eyeY, 10, 10);
        SplashKit.FillRectangle(Color.Red, centerX - 10, mouthY, 20, 10);
        SplashKit.FillRectangle(Color.Red, centerX - 8, mouthY + 2, 16, 6);
    }
}

// Subclass Mexy
public class Mexy : Robot
{
    public Mexy(Window gameWindow, Player player) : base(gameWindow, player) { }

    public override void Draw()
    {
        double centerX = X + Width / 2;
        double centerY = Y + Height / 2;
        double eyeY = Y + 10;
        double mouthY = Y + 35;

        // Draw a rectangle for the body
        SplashKit.FillRectangle(Color.Blue, X, Y, Width, Height);

        // Draw eyes
        SplashKit.FillRectangle(Color.Black, centerX - 10, eyeY, 10, 10);
        SplashKit.FillRectangle(Color.Black, centerX + 10, eyeY, 10, 10);
        SplashKit.FillRectangle(Color.White, centerX - 8, eyeY + 2, 6, 6);
        SplashKit.FillRectangle(Color.White, centerX + 12, eyeY + 2, 6, 6);

        // Draw mouth
        SplashKit.FillRectangle(Color.Black, centerX - 15, mouthY, 30, 5);
    }
}

// Subclass Roundy
public class Roundy : Robot
{
    public Roundy(Window gameWindow, Player player) : base(gameWindow, player) { }

    public override void Draw()
    {
        double centerX = X + Width / 2;
        double centerY = Y + Height / 2;
        double eyeY = Y + 15;
        double mouthY = Y + 35;

        // Draw a pentagon for the body
        Point2D[] pentagon = new Point2D[]
        {
            new Point2D { X = centerX, Y = centerY - 40 },
            new Point2D { X = centerX + 30, Y = centerY - 10 },
            new Point2D { X = centerX + 20, Y = centerY + 30 },
            new Point2D { X = centerX - 20, Y = centerY + 30 },
            new Point2D { X = centerX - 30, Y = centerY - 10 }
        };

        for (int i = 0; i < pentagon.Length; i++)
        {
            Point2D start = pentagon[i];
            Point2D end = pentagon[(i + 1) % pentagon.Length];
            SplashKit.DrawLine(Color.Green, start, end);
        }

        // Draw eyes
        SplashKit.FillCircle(Color.Black, centerX - 10, eyeY, 5);
        SplashKit.FillCircle(Color.Black, centerX + 10, eyeY, 5);

        // Draw mouth
        SplashKit.FillRectangle(Color.Black, centerX - 10, mouthY, 20, 5);
    }
}

