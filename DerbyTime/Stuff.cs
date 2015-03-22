using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace DerbyTime
{
    public class ConfigDetails
    {
        public int PackNumber { get; private set; }
        public string PackLocation { get; private set; }
        public string ChosenScheduler { get; private set; }
        public int NumberOfLanes { get; private set; }
        public bool Shuffle { get; private set; }
        public bool SaveRace { get; private set; }
        public ConfigDetails(int PackNumber, string PackLocation, string ChosenScheduler, int NumberOfLanes, bool Shuffle, bool SaveRace)
        {
            this.PackNumber = PackNumber;
            this.PackLocation = PackLocation;
            this.ChosenScheduler = ChosenScheduler;
            this.NumberOfLanes = NumberOfLanes;
            this.Shuffle = Shuffle;
            this.SaveRace = SaveRace;
        }
    }

    public class Racer
    {
        public int raceNo { get; private set; }
        public int pack { get; private set; }
        public Den den { get; private set; }
        public string name { get; private set; }

        public Racer(int raceNo, int pack, Den den, string name)
        {
            this.raceNo = raceNo;
            this.pack = pack;
            this.den = den;
            this.name = name;
        }
    }

    public enum Den { Webelos = 5, Bear = 4, Wolf = 3, Tiger = 2, Bobcat = 1, None = 0 }

    public class Item
    {
        public string Name;
        public int Value;
        public Item(string name, int value, int cars)
        {
            Name = value.ToString() + "  (" + (cars*value).ToString() + " Heats)";
            if (!string.IsNullOrEmpty(name))
                Name += " | " + name;
            Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }
    }

    public class ImageHandling
    {
        public static Rectangle GetScaledRectangle(Image img, Rectangle thumbRect)
        {
            if (img.Width < thumbRect.Width && img.Height < thumbRect.Height)
                return new Rectangle(thumbRect.X + ((thumbRect.Width - img.Width) / 2), thumbRect.Y + ((thumbRect.Height - img.Height) / 2), img.Width, img.Height);

            int sourceWidth = img.Width;
            int sourceHeight = img.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)thumbRect.Width / (float)sourceWidth);
            nPercentH = ((float)thumbRect.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            if (destWidth.Equals(0))
                destWidth = 1;
            if (destHeight.Equals(0))
                destHeight = 1;

            Rectangle retRect = new Rectangle(thumbRect.X, thumbRect.Y, destWidth, destHeight);

            if (retRect.Height < thumbRect.Height)
                retRect.Y = retRect.Y + Convert.ToInt32(((float)thumbRect.Height - (float)retRect.Height) / (float)2);

            if (retRect.Width < thumbRect.Width)
                retRect.X = retRect.X + Convert.ToInt32(((float)thumbRect.Width - (float)retRect.Width) / (float)2);

            return retRect;
        }

        public static Image GetResizedImage(Image img, Rectangle rect)
        {
            Bitmap b = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, rect.Width, rect.Height);
            g.Dispose();

            try
            {
                return (Image)b.Clone();
            }
            finally
            {
                b.Dispose();
                b = null;
                g = null;
            }
        }
    }
}
