using System;
using System.Collections.Generic;
using SplashKitSDK;

public class RobotDodge
{
    private readonly List<Robot> _robots = new List<Robot>();
    private readonly Window _gameWindow;
    private readonly Player _player;
    private bool _quit = false;
    private const int RobotSpawnInterval = 2000;
    private SplashKitSDK.Timer _spawnTimer = new SplashKitSDK.Timer("Spawn Timer");

    public Player Player => _player;

    public RobotDodge(Window gameWindow)
    {
        _gameWindow = gameWindow;
        _player = new Player(_gameWindow);
        _spawnTimer.Start();
    }

    public bool Quit => _quit || _player.Quit;

    public void HandleInput()
    {
        _player.HandleInput();
    }

    public void Update()
    {
        _player.StayOnWindow(_gameWindow);

        if (_spawnTimer.Ticks >= RobotSpawnInterval)
        {
            SpawnRobot();
            _spawnTimer.Reset();
        }

        foreach (var robot in _robots)
        {
            robot.Update();
            if (_player.CollidedWith(robot))
            {
                _player.DecreaseLives();
                _robots.Remove(robot);
                break;
            }
        }

        _player.UpdateBullets(_robots);

        _player.IncreaseScore();
    }

    public void Draw()
    {
        _player.Draw();

        foreach (var robot in _robots)
        {
            robot.Draw();
        }

        _player.DrawBullets();
    }

    private void SpawnRobot()
    {
        int robotType = SplashKit.Rnd(1, 4); // 1 = Boxy, 2 = Mexy, 3 = Roundy

        Robot robot;
        switch (robotType)
        {
            case 1:
                robot = new Boxy(_gameWindow, _player);
                break;
            case 2:
                robot = new Mexy(_gameWindow, _player);
                break;
            case 3:
                robot = new Roundy(_gameWindow, _player);
                break;
            default:
                robot = new Boxy(_gameWindow, _player);
                break;
        }

        _robots.Add(robot);
    }
}
