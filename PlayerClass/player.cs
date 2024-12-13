using SplashKitSDK;


    public class Player
    {
        private Bitmap _PlayerBitmap;

        public double X { get; private set; }
        public double Y { get; private set; }
        public int Width {
        
        get
        {

          return _PlayerBitmap.Width;

        }

        }
        public int Height 
        
        {
        get {

            return _PlayerBitmap.Height;

            }
        }

        public Player(Window gameWindow)
        {
            _PlayerBitmap = new Bitmap("Player", "/Users/shadankhan/Downloads/Resources/images/Player.png");
            X = (gameWindow.Width - _PlayerBitmap.Width) / 2;
            Y = (gameWindow.Height - _PlayerBitmap.Height) / 2;
        }

        public void Draw()
        {
            _PlayerBitmap.Draw(X, Y);
        }
    }

