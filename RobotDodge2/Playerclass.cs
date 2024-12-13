using SplashKitSDK;
#nullable disable

public class Player
{
private Bitmap _PlayerBitmap;

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

public Player(Window gameWindow)
{
_PlayerBitmap = new Bitmap("Player", "Resources 2/images/Player.png");
X = (gameWindow.Width - Width) / 2;
Y = (gameWindow.Height - Height) / 2;
Quit = false;
}

public void Draw()
{
_PlayerBitmap.Draw(X, Y);
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
}