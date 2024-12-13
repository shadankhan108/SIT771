using SplashKitSDK;
 #nullable disable

 public class Robot
 {
 public double X
 {
 get; private set;
}
 public double Y
 {
 get; private set;
 }

 private Vector2D Velocity
 {
 get; set;
 }

 public Color MainColor
 {
 get; private set;
 }
 public int Width
 {
 get
 {
 return 50;
 }
 }
 public int Height
 {
 get
 {
 return 50;
 }
 }
 public Circle CollisionCircle
 {
 get; private set;
 }

 public Robot(Window gameWindow, Player player)
 {
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

 const int SPEED = 4;
 Point2D fromPt = new Point2D { X = X, Y = Y };
 Point2D toPt = new Point2D { X = player.X, Y = player.Y };
 Vector2D dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(X, Y,
,→ fromPt, toPt));

 Velocity = SplashKit.VectorMultiply(dir, SPEED);
 }

 public void Update()
 {
 X += Velocity.X;
 Y += Velocity.Y;

 CollisionCircle = SplashKit.CircleAt(X + Width / 2, Y + Height / 2, 20);
 }

 public void Draw()
 {
 double leftX = X + 12;
 double rightX = X + 27;
 double eyeY = Y + 10;
 double mouthY = Y + 30;

 SplashKit.FillRectangle(Color.Gray, X, Y, Width, Height);
 SplashKit.FillRectangle(Color.Red, leftX, eyeY, 10, 10);
 SplashKit.FillRectangle(Color.Red, rightX, eyeY, 10, 10);
 SplashKit.FillRectangle(Color.Red, leftX, mouthY, 25, 10);
 SplashKit.FillRectangle(Color.Red, leftX + 2, mouthY + 2, 21, 6);
 }

 public bool IsOffscreen(Window screen)
 {
 return X < -Width || X > screen.Width || Y < -Height || Y > screen.Height;
 }
 }