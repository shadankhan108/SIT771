using SplashKitSDK;
using System;

public class Bullet
{
    private const float Speed = 10f;
    private const float Radius = 4f;

    public double DirectionX { get; private set; }
    public double DirectionY { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    //The activity status of the bullet
    public bool IsActive { get; private set; }
    //The constructor
    public Bullet()
    {
        IsActive = false;
    }
    //The shoot method.
    public void Shoot(double startX, double startY, double targetX, double targetY)
    {
        X = startX;
        Y = startY;
        IsActive = true;

        double dx = targetX - startX;
        double dy = targetY - startY;
        double magnitude = Math.Sqrt(dx * dx + dy * dy);

        DirectionX = dx / magnitude;
        DirectionY = dy / magnitude;

        Move();
    }

    public void Update()
    {
        if (IsActive)
        {
            Move();

            if (IsOffscreen())
            {
                Deactivate();
            }
        }
    }

        public bool CollidedWith(Robot otherRobot)
    {
    double deltaX = this.X - otherRobot.X;
    double deltaY = this.Y - otherRobot.Y;
    double combinedRadius = Radius + otherRobot.CollisionCircle.Radius;

    // Calculate the squared distance between the centers
    double squaredDistance = deltaX * deltaX + deltaY * deltaY;

    // Compare the squared distance with the squared combined radius to avoid computing the square root
    return squaredDistance < (combinedRadius * combinedRadius);
    }


    public void Draw()
    {
        if (IsActive)
        {
            SplashKit.FillCircle(Color.Red, X, Y, Radius);
        }
    }


    public void Deactivate()
    {
        //Deactivate the bullet
        IsActive = false;
    }


    private bool IsOffscreen()
    {
        bool ret=false;
        ret|=(X<0);
        ret|=(X > SplashKit.ScreenWidth());
        ret|=(Y < 0);
        ret|=(Y > SplashKit.ScreenHeight());
        return ret;
    }
    private void Move()
    {
        // Multipying the directions with the speed.
        Y += DirectionY * Speed;
        X += DirectionX * Speed;
        
    }


}
