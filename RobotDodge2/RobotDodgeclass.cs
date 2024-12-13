using SplashKitSDK;
#nullable disable

public class RobotDodge
{
private Player _Player;
private Robot _TestRobot;
private Window _GameWindow;

public bool Quit
{
get
{
return _Player.Quit;
}
}

public RobotDodge(Window gameWindow)
{
_GameWindow = gameWindow;
_Player = new Player(gameWindow);
_TestRobot = RandomRobot();
}
public void HandleInput()
{
_Player.HandleInput();
_Player.StayOnWindow(_GameWindow);
}

public void Draw()
{
_TestRobot.Draw();
_Player.Draw();
_Player.StayOnWindow(_GameWindow);
}

public void Update()
{
if (_Player.CollidedWith(_TestRobot))
{
_TestRobot = RandomRobot();
}
}

public Robot RandomRobot()
{
return new Robot(_GameWindow);
}
}
