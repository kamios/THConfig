using System.Globalization;

namespace Turbo.Plugins.Default
{

    public class BloodShardPlugin : BasePlugin
	{

        public TopLabelDecorator RedDecorator { get; set; }
        public TopLabelDecorator YellowDecorator { get; set; }
        public TopLabelDecorator GreenDecorator { get; set; }

		public BloodShardPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            //TextFunc = () => (500 + Hud.Game.Me.HighestSoloRiftLevel * 10 - Hud.Game.Me.Materials.BloodShard).ToString("D", CultureInfo.InvariantCulture),
            RedDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 100, 100, true, false, 255, 0, 0, 0, true),
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 1.0f,
                TextFunc = () => Hud.Game.Me.Materials.BloodShard.ToString("D", CultureInfo.InvariantCulture),
                HintFunc = () => "amount of blood shards"
            };

            YellowDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 205, 50, true, false, false),
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 1.0f,
                TextFunc = () => Hud.Game.Me.Materials.BloodShard.ToString("D", CultureInfo.InvariantCulture),
                HintFunc = () => "amount of blood shards"
            };

            GreenDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 100, 130, 100, false, false, false),
                BackgroundTexture1 = Hud.Texture.ButtonTextureGray,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureOrange,
                BackgroundTextureOpacity1 = 1.0f,
                BackgroundTextureOpacity2 = 1.0f,
                TextFunc = () => Hud.Game.Me.Materials.BloodShard.ToString("D", CultureInfo.InvariantCulture),
                HintFunc = () => "amount of blood shards"
            };
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_window_hud_overlay").Rectangle;

            var remaining = 500 + Hud.Game.Me.HighestSoloRiftLevel * 10 - Hud.Game.Me.Materials.BloodShard;

            var decorator = remaining < 100 ? RedDecorator : (remaining < 200 ? YellowDecorator : GreenDecorator);
            decorator.Paint(uiRect.Left + uiRect.Width * 0.664f, uiRect.Top + uiRect.Height * 0.88f, uiRect.Width * 0.038f, uiRect.Height * 0.12f, HorizontalAlign.Center);
        }

    }

}