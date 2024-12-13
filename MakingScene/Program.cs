using System;
using SplashKitSDK;

namespace SimpleAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Window window = new Window("Simple Animation", 800, 600);

            
            Bitmap image1 = new Bitmap("image1", "/Users/shadankhan/Downloads/pngaaa.com-1271374.png");
            Bitmap image2 = new Bitmap("image2", "/Users/shadankhan/Downloads/silhouette-3577338_1280.png");

            
            SoundEffect sound1 = new SoundEffect("sound1", "/Users/shadankhan/Downloads/mixkit-cars-starting-1561.wav");
            SoundEffect sound2 = new SoundEffect("sound2", "/Users/shadankhan/Downloads/whip-123738.mp3");

            
            while (!window.CloseRequested)
            {
               
                window.Clear(Color.White);

                
                window.DrawBitmap(image1, 0, 0);

                
                window.Refresh();

               
                sound1.Play();

              
                SplashKit.Delay(5000);

               
                window.Clear(Color.White);

                
                window.DrawBitmap(image2, 0, 0);

               
                window.Refresh();

               
                sound2.Play();

               
                SplashKit.Delay(5000);
            }
        }
    }
}





