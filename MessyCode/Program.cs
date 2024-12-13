using System;
using SplashKitSDK;

#nullable disable

namespace ConfusingCode
{
    public class Application
    {
        public static void Main()
        {
            GalacticGame cosmos = new GalacticGame();
            cosmos.Start();
        }
    }

    public class GalacticGame
    {
        private Spaceship interstellarVessel;
        private Window displayWindow;

        public GalacticGame()
        {
            InitializeWorld();
        }

        private void InitializeWorld()
        {
            LoadAssets();
            ConstructSpaceship();
        }

        private void LoadAssets()
        {
            SplashKit.LoadBitmap("Projectile", "Aquarii.png");
            SplashKit.LoadBitmap("Vessel", "Aquarii.png");
            SplashKit.LoadBitmap("ProjectileBitmap", "Aquarii.png");
        }

        private void ConstructSpaceship()
        {
            interstellarVessel = new Spaceship { PosX = 300, PosY = 300 };
        }

        public void Start()
        {
            InitializeDisplay();

            while (!displayWindow.CloseRequested)
            {
                HandleEvents();
                ProcessInput();
                UpdateWorld();
                RenderWorld();
            }

            CloseDisplay();
        }

        private void InitializeDisplay()
        {
            displayWindow = new Window("Cosmic Voyage", 600, 600);
        }

        private void HandleEvents()
        {
            SplashKit.ProcessEvents();
        }

        private void ProcessInput()
        {
            if (SplashKit.KeyDown(KeyCode.UpKey)) { interstellarVessel.Move(4, 0); }
            if (SplashKit.KeyDown(KeyCode.DownKey)) { interstellarVessel.Move(-4, 0); }
            if (SplashKit.KeyDown(KeyCode.LeftKey)) { interstellarVessel.Rotate(-4); }
            if (SplashKit.KeyDown(KeyCode.RightKey)) { interstellarVessel.Rotate(4); }
            if (SplashKit.KeyTyped(KeyCode.SpaceKey)) { interstellarVessel.Fire(); }
        }

        private void UpdateWorld()
        {
            interstellarVessel.Update();
        }

        private void RenderWorld()
        {
            displayWindow.Clear(Color.Black);
            displayWindow.DrawRectangle(Color.DarkBlue, 0, 0, displayWindow.Width, displayWindow.Height);

            interstellarVessel.Draw();
            displayWindow.Refresh(60);
        }

        private void CloseDisplay()
        {
            displayWindow.Close();
            displayWindow = null;
        }
    }

    public class Spaceship
    {
        private double positionX, positionY;
        private double orientation;
        private Bitmap shipBitmap;
        private Projectile missile;

        public Spaceship()
        {
            InitializeCraft();
        }

        private void InitializeCraft()
        {
            orientation = 270;
            shipBitmap = SplashKit.BitmapNamed("Vessel");
            missile = new Projectile();
        }

        public double PosX { get; set; }
        public double PosY { get; set; }
        public double Orientation { get; set; }

        public void Rotate(double amount)
        {
            orientation = (orientation + amount) % 360;
        }

        public void Draw()
        {
            shipBitmap.Draw(positionX, positionY, SplashKit.OptionRotateBmp(orientation));
            missile.Draw();
        }

        public void Fire()
        {
            Matrix2D anchorMatrix = SplashKit.TranslationMatrix(SplashKit.PointAt(shipBitmap.Width / 2, shipBitmap.Height / 2));
            Matrix2D result = SplashKit.MatrixMultiply(SplashKit.IdentityMatrix(), SplashKit.MatrixInverse(anchorMatrix));
            result = SplashKit.MatrixMultiply(result, SplashKit.RotationMatrix(orientation));
            result = SplashKit.MatrixMultiply(result, anchorMatrix);
            result = SplashKit.MatrixMultiply(result, SplashKit.TranslationMatrix(PosX, PosY));

            Vector2D vector = new Vector2D { X = shipBitmap.Width, Y = shipBitmap.Height / 2 };
            vector = SplashKit.MatrixMultiply(result, vector);
            missile = new Projectile(vector.X, vector.Y, Orientation);
        }

        public void Update()
        {
            missile.Update();
        }

        public void Move(double amountForward, double amountStrafe)
        {
            Vector2D movement = new Vector2D { X = amountForward, Y = amountStrafe };
            Matrix2D rotation = SplashKit.RotationMatrix(orientation);
            movement = SplashKit.MatrixMultiply(rotation, movement);
            positionX += movement.X;
            positionY += movement.Y;
        }
    }

    public class Projectile
    {
        private Bitmap projectileBitmap;
        private double positionX, positionY, orientation;
        private bool isActive;

        public Projectile(double x, double y, double orientation)
        {
            InitializeProjectile(x, y, orientation);
        }

        private void InitializeProjectile(double x, double y, double orientation)
        {
            projectileBitmap = SplashKit.BitmapNamed("ProjectileBitmap");
            this.positionX = x - projectileBitmap.Width / 2;
            this.positionY = y - projectileBitmap.Height / 2;
            this.orientation = orientation;
            isActive = true;
        }

        public Projectile()
        {
            isActive = false;
        }

        public void Update()
        {
            const int speed = 8;
            Vector2D movement = new Vector2D { X = speed };
            Matrix2D rotation = SplashKit.RotationMatrix(orientation);
            movement = SplashKit.MatrixMultiply(rotation, movement);
            positionX += movement.X;
            positionY += movement.Y;

            if (positionX > SplashKit.ScreenWidth() || positionX < 0 || positionY > SplashKit.ScreenHeight() || positionY < 0)
            {
                isActive = false;
            }
        }

        public void Draw()
        {
            if (isActive)
            {
                DrawingOptions options = SplashKit.OptionRotateBmp(orientation);
                projectileBitmap.Draw(positionX, positionY, options);
            }
        }
    }
}
