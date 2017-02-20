using System;

namespace Turbo.Plugins.Default
{

    public class StandardPingRadiusTransformator : IRadiusTransformator
    {

        public IController Hud { get; private set; }

        public int PingSpeed { get; set; }
        public float RadiusMinimumMultiplier { get; set; }
        public float RadiusMaximumMultiplier { get; set; }

        public StandardPingRadiusTransformator(IController hud, int pingSpeed)
        {
            Hud = hud;
            PingSpeed = pingSpeed;
            RadiusMinimumMultiplier = 0.5f;
            RadiusMaximumMultiplier = 1.0f;
        }

        public float TransformRadius(float radius)
        {
            if (PingSpeed <= 0) return radius;

            var msec = Hud.Game.CurrentRealTimeMilliseconds;
            if ((Math.Floor((double)msec / PingSpeed)) % 2 == 1)
            {
                return radius * (RadiusMinimumMultiplier + (RadiusMaximumMultiplier - RadiusMinimumMultiplier) * (msec % PingSpeed) / PingSpeed);
            }
            else
            {
                return radius * (RadiusMaximumMultiplier - (RadiusMaximumMultiplier - RadiusMinimumMultiplier) * (msec % PingSpeed) / PingSpeed);
            }
        }

    }

}