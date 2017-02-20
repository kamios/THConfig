namespace Turbo.Plugins.PsychosPlugins
{
using Turbo.Plugins.Default;

    public class ShrineLabelPlugin : BasePlugin 
    {
        public WorldDecoratorCollection BlessedShrineDecorator { get; set; }
        public WorldDecoratorCollection EnlightenedShrineDecorator { get; set; }
        public WorldDecoratorCollection FortuneShrineDecorator { get; set; }
        public WorldDecoratorCollection FrenziedShrineDecorator { get; set; }
        public WorldDecoratorCollection EmpoweredShrineDecorator { get; set; }
        public WorldDecoratorCollection FleetingShrineDecorator { get; set; }
        public WorldDecoratorCollection PowerPylonDecorator { get; set; }
        public WorldDecoratorCollection ConduitPylonDecorator { get; set; }
        public WorldDecoratorCollection ChannelingPylonDecorator { get; set; }
        public WorldDecoratorCollection ShieldPylonDecorator { get; set; }
        public WorldDecoratorCollection SpeedPylonDecorator { get; set; }
        public WorldDecoratorCollection BanditShrineDecorator { get; set; }
        public string BlessedShrineName { get; set; }
        public string EnlightenedShrineName { get; set; }
        public string FortuneShrineName { get; set; }
        public string FrenziedShrineName { get; set; }
        public string EmpoweredShrineName { get; set; }
        public string FleetingShrineName { get; set; }
        public string PowerPylonName { get; set; }
        public string ConduitPylonName { get; set; }
        public string ChannelingPylonName { get; set; }
        public string ShieldPylonName { get; set; }
        public string SpeedPylonName { get; set; }
        public string BanditShrineName { get; set; }
        public bool UseCustomColors { get; set; }
        public bool UseCustomNames { get; set; }

        public ShrineLabelPlugin() 
        {
            Enabled = true;
            UseCustomColors = false;
            UseCustomNames = false;
        }

        public override void Load(IController hud) 
        {
            base.Load(hud);

            BlessedShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            EnlightenedShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            FortuneShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            FrenziedShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            EmpoweredShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            FleetingShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            PowerPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            ConduitPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            ChannelingPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            ShieldPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            SpeedPylonDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            BanditShrineDecorator = new WorldDecoratorCollection(
                new MapLabelDecorator(Hud) {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                }
            );

            BlessedShrineName = "Blessed Shrine";
            EnlightenedShrineName = "Enlightened Shrine";
            FortuneShrineName = "Fortune Shrine";
            FrenziedShrineName = "Frenzied Shrine";
            EmpoweredShrineName = "Empowered Shrine";
            FleetingShrineName = "Fleeting Shrine";
            PowerPylonName = "Power Pylon";
            ConduitPylonName = "Conduit Plyon";
            ChannelingPylonName = "Channeling Pylon";
            ShieldPylonName = "Shield Pylon";
            SpeedPylonName = "Speed Pylon";
            BanditShrineName = "Bandit Shrine";
        }
            
        public override void Customize()
        {
            if (UseCustomColors == false && UseCustomNames == false)
            {
                Hud.RunOnPlugin<ShrinePlugin>(plugin =>
                {
                    plugin.AllShrineDecorator.Add(new MapLabelDecorator(Hud)
                    {
                        LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                        RadiusOffset = 5.0f,
                    });
                });
            }
        }

        public override void PaintWorld(WorldLayer layer) {
            var ShrineName = string.Empty;
            if (UseCustomColors == true || UseCustomNames == true)
            {
                var shrines = Hud.Game.Shrines;
                foreach (var shrine in shrines) 
                {
                    switch (shrine.Type) 
                    {
                        case ShrineType.BlessedShrine:
                            if (UseCustomNames == true){ShrineName = BlessedShrineName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            BlessedShrineDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.EnlightenedShrine:
                        if (UseCustomNames == true){ShrineName = EnlightenedShrineName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            EnlightenedShrineDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.FortuneShrine:
                        if (UseCustomNames == true){ShrineName = FortuneShrineName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            FortuneShrineDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.FrenziedShrine:
                        if (UseCustomNames == true){ShrineName = FrenziedShrineName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            FrenziedShrineDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.EmpoweredShrine:
                        if (UseCustomNames == true){ShrineName = EmpoweredShrineName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            EmpoweredShrineDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.FleetingShrine:
                        if (UseCustomNames == true){ShrineName = FleetingShrineName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            FleetingShrineDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.PowerPylon:
                        if (UseCustomNames == true){ShrineName = PowerPylonName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            PowerPylonDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.ConduitPylon:
                        if (UseCustomNames == true){ShrineName = ConduitPylonName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            ConduitPylonDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.ChannelingPylon:
                        if (UseCustomNames == true){ShrineName = ChannelingPylonName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            ChannelingPylonDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.ShieldPylon:
                        if (UseCustomNames == true){ShrineName = ShieldPylonName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            ShieldPylonDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.SpeedPylon:
                        if (UseCustomNames == true){ShrineName = SpeedPylonName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            SpeedPylonDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                        case ShrineType.BanditShrine:
                        if (UseCustomNames == true){ShrineName = BanditShrineName;} else {ShrineName = shrine.SnoActor.NameLocalized;}
                            BanditShrineDecorator.Paint(layer, shrine, shrine.FloorCoordinate, ShrineName);
                            break;
                    }
                }
            }
        }
    }
}