using SplashKitSDK;

public class Bullet
{
    private double _x;
    private double _y;
    private Vector2D _velocity;
    private const int Speed = 10;
    public bool IsActive { get; private set; }

    public Bullet()
    {
        IsActive = false;
    }

    public void Shoot(double fromX, double fromY, double toX, double toY)
    {
        _x = fromX;
        _y = fromY;
        IsActive = true;

        Vector2D direction = SplashKit.UnitVector(SplashKit.VectorPointToPoint(new Point2D { X = fromX, Y = fromY }, new Point2D { X = toX, Y = toY }));
        _velocity = SplashKit.VectorMultiply(direction, Speed);
    }

    public void Update()
    {
        if (!IsActive) return;

        _x += _velocity.X;
        _y += _velocity.Y;

        if (_x < 0 || _x > SplashKit.ScreenWidth() || _y < 0 || _y > SplashKit.ScreenHeight())
        {
            IsActive = false;
        }
    }

    public void Draw()
    {
        if (IsActive)
        {
            SplashKit.FillCircle(Color.Black, _x, _y, 5);
        }
    }

    public bool CollidedWith(Robot robot)
    {
        return SplashKit.CircleAt(_x, _y, 5).Intersects(robot.CollisionCircle);
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}
