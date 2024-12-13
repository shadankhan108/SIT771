using SplashKitSDK; using System;
 public class Bullet
 {
 private const float BulletSpeed = 8f;
 private const float BulletRadius = 5f;

 public double X { get; private set; }
public double Y { get; private set; }

 public double DirectionX { get; private set; }
 public double DirectionY { get; private set; }

 public bool IsActive { get; private set; }

 public Bullet()
 {
 IsActive = false;
 }

 public void Shoot(double startX, double startY, double targetX, double targetY)
 {
 X = startX;
 Y = startY;
 IsActive = true;

 double deltaX = targetX - startX;
 double deltaY = targetY - startY;
 double length = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

 DirectionX = deltaX / length;
 DirectionY = deltaY / length;

 X += DirectionX * BulletSpeed;
 Y += DirectionY * BulletSpeed;
 }

 public void Update()
 {
 if (IsActive)
 {
 X += DirectionX * BulletSpeed;
 Y += DirectionY * BulletSpeed;

 if (X < 0 || X > SplashKit.ScreenWidth() || Y < 0 || Y >
,→ SplashKit.ScreenHeight())
 {
 Deactivate();
 }
 }
 }
 public void Draw()

 {
 if (IsActive)
 {
 SplashKit.FillCircle(Color.Goldenrod, X, Y, BulletRadius);
 }
 }

 public void Deactivate()
 {
 IsActive = false;
 }

 public bool CollidedWith(Robot robot)
 {
double distance = Math.Sqrt(Math.Pow(X - robot.X, 2) + Math.Pow(Y - robot.Y,
,→ 2));
return distance < (BulletRadius + robot.CollisionCircle.Radius);
 }
 )