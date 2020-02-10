using GooseShared;
using SamEngine;
using System.Drawing;

namespace DiscoGoose
{
    public class DiscoGoose : IMod
    {
        public RainbowRender whiteRender;
        public RainbowRender orangeRender;
        
        private bool started = false;

        // Gets called automatically, passes in a class that contains pointers to
        // useful functions we need to interface with the goose.
        void IMod.Init()
        {
            // Subscribe to whatever events we want
            InjectionPoints.PreRenderEvent += new InjectionPoints.PreRenderEventHandler(PreRenderEvent);
        }

        public void PreRenderEvent(GooseEntity goose, Graphics gfx)
        {
            if(!started)
            {
                whiteRender = new RainbowRender(goose.renderData.brushGooseWhite.Color);
                orangeRender = new RainbowRender(goose.renderData.brushGooseOrange.Color);
                
                started = true;
            }

            whiteRender.UpdateColor();
            orangeRender.UpdateColor();

            goose.renderData.brushGooseWhite.Color = whiteRender.AsColor();
            goose.renderData.brushGooseOrange.Color = orangeRender.AsColor();
        }
    }
}
