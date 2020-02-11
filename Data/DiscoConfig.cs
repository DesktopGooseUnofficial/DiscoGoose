using Nett;
using System.IO;

namespace DiscoGoose.Data
{
    public class DiscoConfig
    {
        public bool RandomizeStartColor { get; set; } = true;
        public bool SeparateOrangesFromWhites { get; set; } = true;

        public int Center { get; set; } = 128;
        public int Width { get; set; } = 127;

        public int MaxLoops { get; set; } = 32;
        public float ColorSpeed { get; set; } = .05f;

        public float FrequencyR { get; set; } = 0.3f;
        public float FrequencyG { get; set; } = 0.3f;
        public float FrequencyB { get; set; } = 0.3f;

        public float PhaseR { get; set; } = 0;
        public float PhaseG { get; set; } = 2.09439510239f;
        public float PhaseB { get; set; } = 1.57079632679f;

        public static DiscoConfig GetConfig()
        {
            /* 
             * The "current directory" is where the
             * DesktopGoose executable is
            */
            
            string discoConfig = Path.Combine(Directory.GetCurrentDirectory(), @"Assets\Mods\DiscoGoose\config.toml");
            
            if (!File.Exists(discoConfig))
            {
                Toml.WriteFile(new DiscoConfig(), discoConfig);
            }

            return Toml.ReadFile<DiscoConfig>(discoConfig);
        }
    }
}
