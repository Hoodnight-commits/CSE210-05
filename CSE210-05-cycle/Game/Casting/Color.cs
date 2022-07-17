using System.Collections.Generic;

namespace Tron.Game.Casting
{
    /// <summary>
    /// <para>A color.</para>
    /// <para>The responsibility of Color is to hold and provide information about itself. Color has 
    /// a few convenience methods for comparing and converting them.
    /// </para>
    /// </summary>
    public class Color
    {
        private int green = 0;
        private int blue = 0;
        private int red = 0;
        private int alpha = 255;


        // A new instance of color is using red, green, and blue values.
        public Color(int green, int blue, int red)
        {
            this.green = green;
            this.blue = blue;
            this.red = red;
        }

        // Gets the color's alpha value and returns the alpha value.
        public int getAlpha()
        {
            return alpha;
        }

        // Gets the color's green value and returns the green value.
        public int getGreen()
        {
            return green;
        }
        
        // Gets the color's blue value and returns the green value.
        public int getBlue()
        {
            return blue;
        }

        // Gets the color's red value and returns the green value.
        public int getRed()
        {
            return red;
        }
    }
}