using GooseShared;
using SamEngine;
using System.Drawing;

namespace DiscoGoose
{
    public class DiscoGoose : IMod
    {
        public RainbowRender rainbowRender;
        //public RainbowRender orangeRender;

        private float nextChangeTime = -1f;

        //private bool started = false;

        // Gets called automatically, passes in a class that contains pointers to
        // useful functions we need to interface with the goose.
        void IMod.Init()
        {
            // Subscribe to whatever events we want
            InjectionPoints.PreRenderEvent += new InjectionPoints.PreRenderEventHandler(PreRenderEvent);
            rainbowRender = new RainbowRender();
        }

        public void PreRenderEvent(GooseEntity goose, Graphics gfx)
        {
            /*if(!started)
            {
                whiteRender = new RainbowRender(goose.renderData.brushGooseWhite.Color);
                orangeRender = new RainbowRender(goose.renderData.brushGooseOrange.Color);
                
                started = true;
            }*/

            if (Time.time >= this.nextChangeTime)
            {
                rainbowRender.UpdateColor();
                
                goose.renderData.brushGooseWhite.Color = rainbowRender.AsColor();
                goose.renderData.brushGooseOrange.Color = rainbowRender.AsColor();

                nextChangeTime = Time.time + .05f;
            }
        }
    }
}
