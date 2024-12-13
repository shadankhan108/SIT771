using SplashKitSDK;

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

    private const int GAP = 10;
    private const int SPEED = 5;

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
        _PlayerBitmap = new Bitmap("Player", "/Users/shadankhan/Downloads/Resources/images/Player.png");
        X = (gameWindow.Width - _PlayerBitmap.Width) / 2;
        Y = (gameWindow.Height - _PlayerBitmap.Height) / 2;
        Quit = false;
    }

    public void Draw()
    {
        _PlayerBitmap.Draw(X,Y);
    }
    public void HandleInput()
    {
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= SPEED;
        }
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }

    public void StayOnWindow(Window gameWindow)
    {
        if (X < GAP)
        {
            X = GAP;
        }
        if (X + _PlayerBitmap.Width > gameWindow.Width - GAP)
        {
            X = gameWindow.Width - _PlayerBitmap.Width - GAP;
        }
        if (Y < GAP)
        {
            Y = GAP;
        }
        if (Y + _PlayerBitmap.Height > gameWindow.Height - GAP)
        {
            Y = gameWindow.Height - _PlayerBitmap.Height - GAP;
        }
    }
}