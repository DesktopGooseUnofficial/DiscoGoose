using System;
using System.Drawing;

namespace DiscoGoose.Data
{
    public class RainbowRender
    {
        public int r;
        public int g;
        public int b;

        public int loop;
        
        public bool up;

        public Color AsColor()
        {
            return Color.FromArgb(r, g, b);
        }

        public bool ColorsAreClose(Color other)
        {
            int rDist = Math.Abs(AsColor().R - other.R);
            int gDist = Math.Abs(AsColor().G - other.G);
            int bDist = Math.Abs(AsColor().B - other.B);


            return rDist + gDist + bDist > 5;
        }

        public RainbowRender(bool randomizeColor = false)
        {
            if(randomizeColor)
            {
                for (loop = 0; loop < new Random().Next(0, DiscoGoose.Config.MaxLoops); loop++)
                {
                    Gradient();
                }
            }
        }
        
        public RainbowRender(Color color)
        {
            while(ColorsAreClose(color) && loop < DiscoGoose.Config.MaxLoops)
            {
                Gradient();
                loop++;
            }
        }

        public void Gradient()
        {
            MakeColorGradient(DiscoGoose.Config.FrequencyR,
                              DiscoGoose.Config.FrequencyG,
                              DiscoGoose.Config.FrequencyB,
                              DiscoGoose.Config.PhaseR,
                              DiscoGoose.Config.PhaseG,
                              DiscoGoose.Config.PhaseB,
                              DiscoGoose.Config.Width,
                              DiscoGoose.Config.Center,
                              loop);
        }

        public void UpdateColor()
        {
            Gradient();
            
            if (up)
            {
                if (loop == DiscoGoose.Config.MaxLoops)
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

        public void MakeColorGradient(float frequencyR, float frequencyG, float frequencyB, float phaseR, float phaseG, float phaseB, int center, int width, int index)
        {
            r = (int)(Math.Sin(frequencyR * index + phaseR) * width + center);
            g = (int)(Math.Sin(frequencyG * index + phaseG) * width + center);
            b = (int)(Math.Sin(frequencyB * index + phaseB) * width + center);
        }
    }
}