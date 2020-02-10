using System.Drawing;

namespace DiscoGoose
{
    public class RainbowRender
    {
        public int r;
        public int g;
        public int b;
        public int state;

        public Color AsColor()
        {
            return Color.FromArgb(r, g, b);
        }

        public RainbowRender(Color color)
        {
            r = color.R;
            g = color.G;
            b = color.B;
        }

        /* Loops don't really work here,
         * so a dirty solution it is.
             
         * TODO: See if there's a way I can clean this up
        */
        public void UpdateColor()
        {
            if (state == 0)
            {
                g++;
                if (g >= 255)
                {
                    g = 255;
                    state = 1;
                }
            }
            if (state == 1)
            {
                r--;
                if (r <= 0)
                {
                    r = 0;
                    state = 2;
                }
            }
            if (state == 2)
            {
                b++;
                if (b >= 255)
                {
                    b = 255;
                    state = 3;
                }
            }
            if (state == 3)
            {
                g--;
                if (g <= 0)
                {
                    g = 0;
                    state = 4;
                }
            }
            if (state == 4)
            {
                r++;
                if (r >= 255)
                {
                    r = 255;
                    state = 5;
                }
            }
            if (state == 5)
            {
                b--;
                if (b <= 0)
                {
                    b = 0;
                    state = 0;
                }
            }
        }
    }
}