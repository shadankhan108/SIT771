using SplashKitSDK;

public abstract class Robot
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public Color MainColor { get; private set; }
    public Circle CollisionCircle { get; private set; }
    private Vector2D Velocity { get; set; }

    public int Width => 50;
    public int Height => 50;

    public Robot(Window gameWindow, Player player)
    {
        const int SPEED = 4;

        X = SplashKit.Rnd(gameWindow.Width);
        Y = SplashKit.Rnd(gameWindow.Height);

        if (SplashKit.Rnd() < 0.5)
        {
            X = SplashKit.Rnd(gameWindow.Width);
            Y = SplashKit.Rnd() < 0.5 ? -Height : gameWindow.Height;
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);
            X = SplashKit.Rnd() < 0.5 ? -Width : gameWindow.Width;
        }

        Point2D fromPoint = new Point2D { X = X, Y = Y };
        Point2D toPoint = new Point2D { X = player.X, Y = player.Y };

        MainColor = Color.RandomRGB(200);

        Vector2D direction = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPoint, toPoint));
        Velocity = SplashKit.VectorMultiply(direction, SPEED);
    }

    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;

        double centerX = X + Width / 2;
        double centerY = Y + Height / 2;
        CollisionCircle = SplashKit.CircleAt(centerX, centerY, 20);
    }

    public bool IsOffscreen(Window screen)
    {
        return X < -Width || X > screen.Width || Y < -Height || Y > screen.Height;
    }

    public abstract void Draw();
}

public class Boxy : Robot
{
    public Boxy(Window gameWindow, Player player) : base(gameWindow, player) { }

    public override void Draw()
    {
        double centerX = X + Width / 2;
        double centerY = Y + Width / 2;
        double eyeY = Y + 10;
        double mouthY = Y + 30;

        Point2D[] hexagon = new Point2D[]
        {
            new Point2D { X = centerX - 20, Y = centerY - 30 },
            new Point2D { X = centerX + 20, Y = centerY - 30 },
            new Point2D { X = centerX + 30, Y = centerY },
            new Point2D { X = centerX + 20, Y = centerY + 30 },
            new Point2D { X = centerX - 20, Y = centerY + 30 },
            new Point2D { X = centerX - 30, Y = centerY }
        };

        for (int i = 0; i < hexagon.Length; i++)
        {
            Point2D start = hexagon[i];
            Point2D end = hexagon[(i + 1) % hexagon.Length];
            SplashKit.DrawLine(Color.Gray, start, end);
        }

        SplashKit.FillRectangle(Color.Red, centerX - 15, eyeY, 10, 10);
        SplashKit.FillRectangle(Color.Red, centerX + 5, eyeY, 10, 10);
        SplashKit.FillRectangle(Color.Red, centerX - 10, mouthY, 20, 10);
    }
}

public class Roundy : Robot
{
    public Roundy(Window gameWindow, Player player) : base(gameWindow, player) { }

    public override void Draw()
    {
        double centerX = X + Width / 2;
        double eyeY = Y + 10;
        double mouthY = Y + 30;

        SplashKit.FillCircle(Color.Blue, centerX, centerX, 50);
        SplashKit.FillCircle(Color.Black, centerX - 15, eyeY, 10);
        SplashKit.FillCircle(Color.Black, centerX + 15, eyeY, 10);
        SplashKit.FillRectangle(Color.Black, centerX - 10, mouthY, 20, 10);
    }
}

public class Mexy : Robot
{
    public Mexy(Window gameWindow, Player player) : base(gameWindow, player) { }

    public override void Draw()
    {
        double centerX = X + Width / 2;
        double eyeY = Y + 10;
        double mouthY = Y + 30;

        Point2D[] triangle = new Point2D[]
        {
            new Point2D { X = centerX, Y = centerY - 50 },
            new Point2D { X = centerX - 50, Y = centerY + 50 },
            new Point2D { X = centerX + 50, Y = centerY + 50 }
        };

        for (int i = 0; i < triangle.Length; i++)
        {
            Point2D start = triangle[i];
            Point2D end = triangle[(i + 1) % triangle.Length];
            SplashKit.DrawLine(Color.Green, start, end);
        }

        SplashKit.FillCircle(Color.Black, centerX - 15, eyeY, 10);
        SplashKit.FillCircle(Color.Black, centerX + 15, eyeY, 10);
        SplashKit.FillRectangle(Color.Black, centerX - 10, mouthY, 20, 10);
    }
}
