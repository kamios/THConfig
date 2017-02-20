using System.Linq;

namespace Turbo.Plugins.Default
{

    public class GoblinPlugin : BasePlugin
	{

        public WorldDecoratorCollection GoblinDecorator { get; set; }
        public WorldDecoratorCollection PortalDecorator { get; set; }

		public GoblinPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            GoblinDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 255, 255, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 8.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 0, 120, 0, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 2.5f,
                    ShapePainter = new CircleShapePainter(Hud),
                }
                );

            PortalDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 255, 255, 255, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 8.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                },
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(180, 120, 0, 0, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 2.5f,
                    ShapePainter = new CircleShapePainter(Hud),
                }
                );
        }
		
        public override void PaintWorld(WorldLayer layer)
        {
            var portals = Hud.Game.Actors.Where(x => x.SnoActor.Sno == 410460);
            foreach (var actor in portals)
            {
                PortalDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
            }

            var goblins = Hud.Game.AliveMonsters.Where(x => x.SnoMonster.Priority == MonsterPriority.goblin);
            foreach (var monster in goblins)
            {
                GoblinDecorator.Paint(layer, monster, monster.FloorCoordinate, null);
            }
        }

    }

}