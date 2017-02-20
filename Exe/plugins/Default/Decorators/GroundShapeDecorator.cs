using System.Collections.Generic;

namespace Turbo.Plugins.Default
{

    public enum GroundShape { X }

    // this is not a plugin, just a helper class to display labels on the ground
    public class GroundShapeDecorator: IWorldDecoratorWithRadius
    {

        public bool Enabled { get; set; }
        public WorldLayer Layer { get; private set; }
        public IController Hud { get; set; }

        public IBrush Brush { get; set; }
        public GroundShape Shape { get; set; }
        public bool HasShadow { get; set; }
        private IBrush _shadowBrush;

        public float Radius { get; set; }
        public IRadiusTransformator RadiusTransformator { get; set; }

        public GroundShapeDecorator(IController hud)
        {
            Enabled = true;
            Layer = WorldLayer.Ground;
            Hud = hud;

            _shadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1);
            Shape = GroundShape.X;
            HasShadow = true;
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (Brush == null) return;
            if (Radius <= 0) return;

            var sc = coord.ToScreenCoordinate(true, true);

            var screenBorderPadding = Hud.Window.Size.Height * 0.01f;

            var radius = RadiusTransformator != null ? RadiusTransformator.TransformRadius(Radius) : Radius;

            switch (Shape)
            {
                case GroundShape.X:
                    if (Brush.StrokeStyle.DashStyle == SharpDX.Direct2D1.DashStyle.Solid)
                    {
                        _shadowBrush.StrokeWidth = Brush.StrokeWidth >= 0 ? Brush.StrokeWidth + 1 : Brush.StrokeWidth - 1;
                        _shadowBrush.DrawWorldPlus(radius, coord.X, coord.Y, coord.Z);
                    }
                    Brush.DrawWorldPlus(radius, coord.X, coord.Y, coord.Z);
                    break;
            }
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return Brush;
            yield return _shadowBrush;
        }

    }

}