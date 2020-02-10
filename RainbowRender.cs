using System;
using System.Drawing;

namespace DiscoGoose
{
    public class RainbowRender
    {
        public int r;
        public int g;
        public int b;

        public int phase = 1;
        public int center;
        public int width;
        public int loop;
        public int maxLoops = 32;
        
        public bool up;

        public Color AsColor()
        {
            return Color.FromArgb(r, g, b);
        }

        public void UpdateColor()
        {
            MakeColorGradient(.3f, .3f, .3f, 0, 2, 4, loop);
            
            if (up)
            {
                if (loop == maxLoops)
                {
                    up = false;
                }
                else
                {
                    loop++;
                }
            }
            else
            {
                if (loop == 0)
                {
                    up = true;
                }
                else
                {
                    loop--;
                }
            }
        }

        public void MakeColorGradient(float frequency1, float frequency2, float frequency3, float phase1, float phase2, float phase3, int index, int center = 128, int width = 127)
        {
            r = (int)(Math.Sin(frequency1 * index + phase1) * width + center);
            g = (int)(Math.Sin(frequency2 * index + phase2) * width + center);
            b = (int)(Math.Sin(frequency3 * index + phase3) * width + center);
        }
    }
}