using System;

using System.Collections.Generic;

using System.Linq;

using Turbo.Plugins.Default;



namespace Turbo.Plugins.CB

{

    public class EliteHealthListPlugin : BasePlugin

    {

        public IFont TextFont { get; set; }

        public IBrush BorderBrush { get; set; }

        public IBrush BackgroundBrush { get; set; }

        public IBrush RareBrush { get; set; }

        public IBrush ChampionBrush { get; set; }



        public EliteHealthListPlugin()

        {

            Enabled = true;

        }



        public override void Load(IController hud)

        {

            base.Load(hud);

            TextFont = Hud.Render.CreateFont("tahoma", 7, 120, 255, 255, 255, false, false, true);
            BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, 1);
            BackgroundBrush = Hud.Render.CreateBrush(255, 125, 120, 120, 0);
            RareBrush = Hud.Render.CreateBrush(255, 255, 128, 0, 0);
            ChampionBrush = Hud.Render.CreateBrush(255, 0, 128, 255, 0);

        }



        public override void PaintWorld(WorldLayer layer)

        {

            var monsters = Hud.Game.AliveMonsters;

            Dictionary<IMonster, string> eliteGroup = new Dictionary<IMonster, string>();



            foreach (var monster in monsters)

            {

                if (monster.Rarity == ActorRarity.Champion || monster.Rarity == ActorRarity.Rare)

                {

                    eliteGroup.Add(monster, String.Join(", ", monster.AffixSnoList));

                }

            }

            Dictionary<IMonster, string> eliteGroup1 = eliteGroup.OrderBy(p => p.Value).ToDictionary(p => p.Key, o => o.Value);



            var px = Hud.Window.Size.Width * 0.00125f;

            var py = Hud.Window.Size.Height * 0.001667f;

            var h = py * 6;

            var w2 = py * 80;

            var count = 0;

            string preStr = null;

            //remove clone

            foreach (var elite in eliteGroup1)

            {

                if (elite.Key.Rarity == ActorRarity.Champion)

                {

                    var eliteCurMaxHealth = 0.0d;

					var eliteMaxHealth = 0.0d;

					bool illusionist = false;

					int same = 0;

					eliteCurMaxHealth = elite.Key.MaxHealth;	

					same = 0;

					foreach (var monster2 in monsters)

					{

					if (eliteMaxHealth < monster2.MaxHealth && monster2.Rarity == ActorRarity.Champion) eliteMaxHealth = monster2.MaxHealth;

					}

					foreach (var monster1 in monsters)

					{

						if (monster1.Rarity == ActorRarity.Champion)

						{

							if (eliteCurMaxHealth == monster1.MaxHealth) same ++;

							if (same == 2) 

							{

								illusionist = true;

								break;

							}

						}

					}

					if (illusionist == false)

                    {

                        var w = elite.Key.CurHealth * w2 / elite.Key.MaxHealth;

                        var text = (elite.Key.CurHealth * 100 / elite.Key.MaxHealth).ToString("f0")+ "%";

                        var layout = TextFont.GetTextLayout(text);

                        if (preStr != elite.Value || preStr == null) count++;

                        var y = py * 8 * count;

                        //BorderBrush.DrawRectangle(x, y, 70, h);

                        BackgroundBrush.DrawRectangle(Hud.Window.Size.Width * 0.125f, y, w2, h);

                        TextFont.DrawText(layout, Hud.Window.Size.Width * 0.125f + px + w2, y - py);

                        ChampionBrush.DrawRectangle(Hud.Window.Size.Width * 0.125f, y, (float)w, h);

                        preStr = elite.Value;

                        count++;

                    }

                }

                if (elite.Key.Rarity == ActorRarity.Rare)

                {

                    var eliteCurMaxHealth = 0.0d;

					var eliteMaxHealth = 0.0d;

					bool illusionist = false;

					int same = 0;

					eliteCurMaxHealth = elite.Key.MaxHealth;	

					same = 0;

					foreach (var monster2 in monsters)

					{

					if (eliteMaxHealth < monster2.MaxHealth && monster2.Rarity == ActorRarity.Rare) eliteMaxHealth = monster2.MaxHealth;

					}

                    foreach (var monster1 in monsters)

					{

						if (monster1.Rarity == ActorRarity.Rare)

						{

							if (eliteCurMaxHealth == monster1.MaxHealth) same ++;

							if (same == 2) 

							{

								illusionist = true;

								break;

							}

						}

					}

					if (illusionist == false)

                    {

                        var w = elite.Key.CurHealth * w2 / elite.Key.MaxHealth;

                        var text = (elite.Key.CurHealth * 100 / elite.Key.MaxHealth).ToString("f0")+ "%";

                        var layout = TextFont.GetTextLayout(text);

                        if (preStr != elite.Value || preStr == null) count++;

                        var y = py * 8 * count;

                        //BorderBrush.DrawRectangle(x, y, 70, h);

                        BackgroundBrush.DrawRectangle(Hud.Window.Size.Width * 0.125f, y, w2, h);

                        TextFont.DrawText(layout, Hud.Window.Size.Width * 0.125f + px + w2, y - py);

                        RareBrush.DrawRectangle(Hud.Window.Size.Width * 0.125f, y, (float)w, h);

                        preStr = elite.Value;

                        count++;

                    }

                }

            }

            eliteGroup.Clear();

        }

    }

}