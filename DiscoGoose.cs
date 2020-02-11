using GooseShared;
using SamEngine;
using System.Drawing;
using DiscoGoose.Data;

namespace DiscoGoose
{
    public class DiscoGoose : IMod
    {
        public static DiscoConfig Config;

        public RainbowRender bodyRainbow;
        public RainbowRender beakAndFeetRainbow;

        private float nextChangeTime = -1f;

        // Gets called automatically, passes in a class that contains pointers to
        // useful functions we need to interface with the goose.
        void IMod.Init()
        {
            Config = DiscoConfig.GetConfig();

            // Subscribe to whatever events we want
            InjectionPoints.PreRenderEvent += new InjectionPoints.PreRenderEventHandler(PreRenderEvent);

            bodyRainbow = new RainbowRender();
            beakAndFeetRainbow = new RainbowRender();

            if (Config.RandomizeStartColor)
            {
                bodyRainbow = new RainbowRender(randomizeColor: true);
                beakAndFeetRainbow = new RainbowRender(randomizeColor: true);
            }

            if (Config.SeparateOrangesFromWhites)
            {
                beakAndFeetRainbow = new RainbowRender(bodyRainbow.AsColor());
            }
        }

        public void PreRenderEvent(GooseEntity goose, Graphics gfx)
        {
            if (Time.time >= nextChangeTime)
            {
                bodyRainbow.UpdateColor();
                beakAndFeetRainbow.UpdateColor();
                
                goose.renderData.brushGooseWhite.Color = bodyRainbow.AsColor();
                goose.renderData.brushGooseOrange.Color = beakAndFeetRainbow.AsColor();

                nextChangeTime = Time.time + Config.ColorSpeed;
            }
        }
    }
}
