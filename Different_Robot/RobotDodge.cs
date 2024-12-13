using SplashKitSDK;
using System.Collections.Generic;

public class RobotDodge
{
    private List<Robot> _robots;
    private Window _gameWindow;
    private Player _player;
    
    
    public Player Player
    {
        get { return _player; }
    }

    public bool Quit
    {
        get { return _player.Quit; }
    }

    public RobotDodge(Window window)
    {
        _gameWindow = window;
        _player = new Player(window, this);
        _robots = new List<Robot>();
    }

    public void HandleInput()
    {
        _player.HandleInput();
        _player.StayOnWindow(_gameWindow);
    }

    public void Update()
    {
        ManageCollisions();

        foreach (Robot robot in _robots)
        {
            robot.Update();
        }

        _player.IncreaseScore();
        _player.UpdateBullets(_robots);

        if (SplashKit.Rnd() < 0.02)
        {
            _robots.Add(CreateRandomRobot());
        }
    }

    public void Draw()
    {
        _gameWindow.Clear(Color.White);

        foreach (Robot robot in _robots)
        {
            robot.Draw();
        }

        _player.Draw();
        _player.DrawBullets();
        _gameWindow.Refresh();
    }

    private void ManageCollisions()
    {
        _robots.RemoveAll(robot =>
        {
            if (robot.IsOffscreen(_gameWindow))
            {
                return true;
            }

            if (_player.CollidedWith(robot))
            {
                _player.DecreaseLives();
                return true;
            }

            return false;
        });
    }

    private Robot CreateRandomRobot()
    {
        List<Func<Robot>> robotFactories = new List<Func<Robot>>
        {
            () => new Boxy(_gameWindow, _player),
            () => new Mexy(_gameWindow, _player),
            () => new Roundy(_gameWindow, _player)
        };

        int randomIndex = (int)(SplashKit.Rnd() * robotFactories.Count);
        return robotFactories[randomIndex]();
    }
}
