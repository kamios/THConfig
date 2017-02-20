using SharpDX;
using System;

namespace Turbo.Plugins.Default
{

    public class OriginalSkillBarPlugin : BasePlugin
    {

        public SkillPainter SkillPainter { get; set; }

        public OriginalSkillBarPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            SkillPainter = new SkillPainter(Hud, true)
            {
                TextureOpacity = 0.0f,
                EnableSkillDpsBar = true,
                EnableDetailedDpsHint = true,
            };
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            foreach (var skill in Hud.Game.Me.Powers.UsedSkills)
            {
                var ui = Hud.Render.GetPlayerSkillUiElement(skill.Key);
                var rect = new RectangleF((float)Math.Round(ui.Rectangle.X) + 0.5f, (float)Math.Round(ui.Rectangle.Y) + 0.5f, (float)Math.Round(ui.Rectangle.Width), (float)Math.Round(ui.Rectangle.Height));

                SkillPainter.Paint(skill, rect);
            }
        }

    }

}