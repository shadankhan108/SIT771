using SplashKitSDK;
 using System;
 #nullable disable

 public class Player
 {
 private Bitmap _PlayerBitmap;

 private Bullet _Bullet;

 private Bitmap _HeartImage;

private RobotDodge _RobotDodge;

 private int _Score = 0;

 SplashKitSDK.Timer _ScoreTimer = new SplashKitSDK.Timer("Score Timer");

 private const double ScoreUpdateTimeInterval = 1000;

 public int Lives { get; private set; } = 5;

 public double X
 {
 get; private set;
 }
 public double Y
 {
 get; private set;
 }
 public bool Quit
 {
get; private set;
 }
 public int Width
 {
 get
 {
 return _PlayerBitmap.Width;
 }
 }
 public int Height
 {
 get
 {
 return _PlayerBitmap.Height;
 }
 }

 public Player(Window gameWindow, RobotDodge robotDodge)
 {
 _PlayerBitmap = new Bitmap("Player", "Player.png");
 _HeartImage = new Bitmap("Heart", "heart.png");

 X = (gameWindow.Width - Width) / 2;
 Y = (gameWindow.Height - Height) / 2;
 _ScoreTimer.Start();
 _Bullet = new Bullet();
 _RobotDodge = robotDodge;
 Quit = false;
 }

 public void Draw(Window gameWindow)
 {
 _PlayerBitmap.Draw(X, Y);

 float heartSpacing = 40f;
 float heartSize = 20;

 for (int i = 0; i < Lives; i++)
 {
 float heartX = gameWindow.Width - (i + 1) * (heartSize + heartSpacing);
 float heartY = 5;

 if (heartX - heartSize > 0 && heartX < gameWindow.Width)
 {
 _HeartImage.Draw(heartX, heartY);
 }
 }

 string scoreText = $"Score: {_Score}";
 SplashKit.DrawText(scoreText, Color.Black, 10, 10);
 }

 public void HandleInput()
 {
 if (SplashKit.KeyDown(KeyCode.RightKey))
 {
 X += 5;
 }

 if (SplashKit.KeyDown(KeyCode.LeftKey))
 {
 X -= 5;
 }

 if (SplashKit.KeyDown(KeyCode.DownKey))
 {
 Y += 5;
 }

 if (SplashKit.KeyDown(KeyCode.UpKey))
 {
 Y -= 5;
 }

 if (SplashKit.KeyTyped(KeyCode.EscapeKey))

 {
 Quit = true;
 }
 }

 public void StayOnWindow(Window gameWindow)
 {
 if (X < 0)
 {
 X = 0;
 }

 if (X + Width > gameWindow.Width)
 {
 X = gameWindow.Width - Width;
 }

 if (Y < 0)
 {
 Y = 0;
 }

 if (Y + Height > gameWindow.Height)
 {
 Y = gameWindow.Height - Height;
 }
 }

 public bool CollidedWith(Robot other)
 {
 return _PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle);
 }

public void DecreaseLives()
{
 Lives--;

 if (Lives <= 0)
 {
 Quit = true;
 }
 }

public void IncreaseScore()
 {
 if (_ScoreTimer.Ticks >= ScoreUpdateTimeInterval)
 {
 _Score++;
 _ScoreTimer.Reset();
 } 
 
 }

 public void ShootBullet()

 {
 if (!_Bullet.IsActive)
 {
 double mouseX = SplashKit.MouseX();
 double mouseY = SplashKit.MouseY();

 _Bullet.Shoot(X + Width / 2, Y + Height / 2, mouseX, mouseY);
 }
 }

 public void UpdateBullets(List<Robot> robots)
 {
 _Bullet.Update();

 List<Robot> robotsToRemove = new List<Robot>();

 foreach (var robot in robots)
 {
 if (_Bullet.IsActive && _Bullet.CollidedWith(robot))
 {
 robotsToRemove.Add(robot);

 _Bullet.Deactivate();
 }
 }

 foreach (var robotToRemove in robotsToRemove)
 {
 robots.Remove(robotToRemove);
 }
 }

 public void DrawBullets()
 {
 _Bullet.Draw();
 }
 }
