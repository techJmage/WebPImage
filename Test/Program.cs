using System;
using System.IO;
using WP = ImageConversion;
namespace Test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            try
            {
                string src = @"C:\Users\uie37359\Pictures\Rule Creation UI-Dashboard.drawio.png";
                string dest = @"C:\Users\uie37359\Pictures\Rule Creation UI-Dashboard.drawio.webp";
                //WP.Convert.PngToWebP(src, dest, 1072, 745);
                //convert png image to webp and save on local path
                using var srcStrm = File.OpenRead(src);
                WP.Convert.ToWebP(srcStrm, dest);
                Console.WriteLine("Done");
                Console.Read();

                //ImageConversion.Convert.PngToWebPFromWeb("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png", "webp.webp", 100, 50);
                //convert web png image to webp and save on local path
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
