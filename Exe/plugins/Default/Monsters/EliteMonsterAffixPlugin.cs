using System.Collections.Generic;

namespace Turbo.Plugins.Default
{

    public class EliteMonsterAffixPlugin : BasePlugin
	{

        public WorldDecoratorCollection WeakDecorator { get; set; }
        public Dictionary<MonsterAffix, WorldDecoratorCollection> AffixDecorators { get; set; }
        public Dictionary<MonsterAffix, string> CustomAffixNames { get; set; }

        public EliteMonsterAffixPlugin()
		{
            Enabled = true;
            Order = 20000;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            WeakDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 50, 50, 50, 0),
                    BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                    TextFont = Hud.Render.CreateFont("tahoma", 5f, 200, 220, 120, 0, false, false, false)
                }
                );

            CustomAffixNames = new Dictionary<MonsterAffix, string>();

            var importantBorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2);
            var importantLabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 255, true, false, false);

            AffixDecorators = new Dictionary<MonsterAffix, WorldDecoratorCollection>();
            AffixDecorators.Add(MonsterAffix.Arcane, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 120, 0, 120, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Desecrator, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 170, 50, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Electrified, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 40, 40, 240, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Frozen, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 120, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.FrozenPulse, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 120, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Jailer, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 120, 0, 120, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Juggernaut, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 200, 0, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Molten, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 170, 50, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Mortar, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 170, 50, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Orbiter, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 40, 40, 240, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Plagued, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 120, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Poison, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 120, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Reflect, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 120, 50, 0, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Thunderstorm, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 40, 40, 240, 0),
                }
                ));
            AffixDecorators.Add(MonsterAffix.Waller, new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BorderBrush = importantBorderBrush,
                    TextFont = importantLabelFont,
                    BackgroundBrush = Hud.Render.CreateBrush(255, 50, 50, 50, 0),
                }
                ));

            AffixDecorators.Add(MonsterAffix.ExtraHealth, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.HealthLink, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Fast, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.FireChains, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Knockback, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Nightmarish, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Illusionist, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Shielding, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Teleporter, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Vampiric, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Vortex, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Wormhole, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Avenger, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.Horde, WeakDecorator);
            AffixDecorators.Add(MonsterAffix.MissileDampening, WeakDecorator);
        }

        public override void PaintWorld(WorldLayer layer)
        {
            var monsters = Hud.Game.AliveMonsters;
            foreach (var monster in monsters)
            {
                foreach (var snoMonsterAffix in monster.AffixSnoList)
                {
                    WorldDecoratorCollection decorator;
                    if (!AffixDecorators.TryGetValue(snoMonsterAffix.Affix, out decorator)) continue;

                    string affixName = null;
                    if (CustomAffixNames.ContainsKey(snoMonsterAffix.Affix))
                    {
                        affixName = CustomAffixNames[snoMonsterAffix.Affix];
                    }
                    else affixName = snoMonsterAffix.NameLocalized;

                    decorator.Paint(layer, monster, monster.FloorCoordinate, affixName);
                }
            }
        }

    }

}