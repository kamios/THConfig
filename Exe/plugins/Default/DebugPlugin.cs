using System;

namespace Turbo.Plugins.Default
{

    public class DebugPlugin : BasePlugin
	{

        public TopLabelDecorator RenderTimeDecorator { get; set; }
        public TopLabelDecorator MemoryUsageDecorator { get; set; }

		public DebugPlugin()
		{
            Enabled = false;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            RenderTimeDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("courier new", 6, 255, 0, 255, 0, true, false, false),
                TextFunc = () => Hud.Stat.RenderPerfCounter.LastValue.ToString("F0") + " (" + Hud.Stat.RenderPerfCounter.LastCount.ToString("F0") + " FPS)",
            };

            MemoryUsageDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("courier new", 6, 255, 255, 50, 50, true, false, false),
                TextFunc = () => (GC.GetTotalMemory(false) / 1024.0 / 1024.0).ToString("F0") + " MB",
            };
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;

            var text = Hud.Stat.RenderPerfCounter.LastValue.ToString("F0") + " (" + Hud.Stat.RenderPerfCounter.LastCount.ToString("F0") + " FPS)";
            RenderTimeDecorator.Paint(Hud.Window.Size.Width * 0.92f, Hud.Window.Size.Height * 0.0000f, Hud.Window.Size.Width * 0.08f, Hud.Window.Size.Height * 0.01f, HorizontalAlign.Right);

            text = (GC.GetTotalMemory(false) / 1024.0 / 1024.0).ToString("F0") + " MB";
            MemoryUsageDecorator.Paint(Hud.Window.Size.Width * 0.84f, Hud.Window.Size.Height * 0.0000f, Hud.Window.Size.Width * 0.08f, Hud.Window.Size.Height * 0.01f, HorizontalAlign.Right);
        }

    }

}