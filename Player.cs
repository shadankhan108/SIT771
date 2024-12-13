using SplashKitSDK;
using System;
using System.Collections.Generic;

public class Player
{
    private Bitmap _playerImage;
    private Bitmap _heartImage;
    private const int MoveSpeed = 5;
    private int _score = 0;
    private SplashKitSDK.Timer _scoreTimer = new SplashKitSDK.Timer("Score Timer");
    private const double ScoreInterval = 1000;
    private List<Bullet> _bullets;

    public int Lives { get; private set; } = 5;
    public double X { get; private set; }
    public double Y { get; private set; }
    public bool Quit { get; private set; }
    public int MaxHeight { get; private set; }
    public int MaxWidth { get; private set; }

    public int Width => _playerImage.Width;
    public int Height => _playerImage.Height;

    public Player(Window gameWindow)
    {
        _playerImage = new Bitmap("Player", "Player.png");
        _heartImage = new Bitmap("Heart", "heart.png");

        X = (gameWindow.Width - _playerImage.Width) / 2;
        Y = (gameWindow.Height - _playerImage.Height) / 2;

        _scoreTimer.Start();
        MaxHeight = gameWindow.Height;
        MaxWidth = gameWindow.Width;
        _bullets = new List<Bullet>();
        Quit = false;
    }

    public void Draw()
    {
        _playerImage.Draw(X, Y);

        const float HeartSpacing = 25f;
        const float HeartSize = 15f;
        const float HeartY = 10f;

        for (int i = 0; i < Lives; i++)
        {
            float heartX = i * (HeartSize + HeartSpacing);
            _heartImage.Draw(heartX, HeartY);
        }

        string scoreText = $"Score: {_score}";
        SplashKit.DrawText(scoreText, Color.Black, MaxWidth - 100, 10);
    }

    public void HandleInput()
    {
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += MoveSpeed;
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= MoveSpeed;
        }
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= MoveSpeed;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += MoveSpeed;
        }
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }

    public void StayOnWindow(Window gameWindow)
    {
        const int BorderGap = 10;

        if (X < BorderGap) X = BorderGap;
        if (X > gameWindow.Width - _playerImage.Width - BorderGap) X = gameWindow.Width - _playerImage.Width - BorderGap;
        if (Y < BorderGap) Y = BorderGap;
        if (Y > gameWindow.Height - _playerImage.Height - BorderGap) Y = gameWindow.Height - _playerImage.Height - BorderGap;
    }

    public bool CollidedWith(Robot other)
    {
        return _playerImage.CircleCollision(X, Y, other.CollisionCircle);
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
        if (_scoreTimer.Ticks >= ScoreInterval)
        {
            _score++;
            _scoreTimer.Reset();
        }
    }

    public void ShootBullet()
    {
        double mouseX = SplashKit.MouseX();
        double mouseY = SplashKit.MouseY();
        Bullet bullet = new Bullet();
        bullet.Shoot(X + Width / 2, Y + Height / 2, mouseX, mouseY);
        _bullets.Add(bullet);
    }

    public void UpdateBullets(List<Robot> robots)
    {
        foreach (var bullet in _bullets)
        {
            bullet.Update();
        }

        List<Robot> robotsToRemove = new List<Robot>();

        foreach (var robot in robots)
        {
            foreach (var bullet in _bullets)
            {
                if (bullet.IsActive && bullet.CollidedWith(robot))
                {
                    robotsToRemove.Add(robot);
                    bullet.Deactivate();
                }
            }
        }

        foreach (var robot in robotsToRemove)
        {
            robots.Remove(robot);
        }
    }

    public void DrawBullets()
    {
        foreach (var bullet in _bullets)
        {
            bullet.Draw();
        }
    }
}
