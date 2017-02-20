namespace Turbo.Plugins.Default
{

    public class InventoryMaterialCountPlugin : BasePlugin
    {

        public IFont MaterialCountFont { get; set; }

        private ISnoItem[] _materialItems, _legendaryMaterials, _otherStuff;
        private ITexture _materialBackgroundImage;

        public InventoryMaterialCountPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            _materialItems = new ISnoItem[] { Hud.Inventory.GetSnoItem(3931359676), Hud.Inventory.GetSnoItem(2709165134), Hud.Inventory.GetSnoItem(3689019703), Hud.Inventory.GetSnoItem(2073430088), Hud.Inventory.GetSnoItem(2087837753) };
            _legendaryMaterials = new ISnoItem[] { Hud.Inventory.GetSnoItem(1948629088), Hud.Inventory.GetSnoItem(1948629089), Hud.Inventory.GetSnoItem(1948629090), Hud.Inventory.GetSnoItem(1948629091), Hud.Inventory.GetSnoItem(1948629092) };
            _otherStuff = new ISnoItem[] { Hud.Inventory.GetSnoItem(1054965529), Hud.Inventory.GetSnoItem(2788723894), Hud.Inventory.GetSnoItem(2622355732), Hud.Inventory.GetSnoItem(1458185494), Hud.Inventory.GetSnoItem(2835237830) };

            MaterialCountFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, false);

            _materialBackgroundImage = Hud.Texture.GetTexture("inventory_materials");
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (!Enabled) return;
            if (clipState != ClipState.Inventory) return;
            if (Hud.Game.Me.CurrentLevelNormalCap != 70) return;

            var uiInv = Hud.Inventory.InventoryMainUiElement;
            if (!uiInv.Visible) return;

            var y = uiInv.Rectangle.Top + uiInv.Rectangle.Height * 0.825f;
            y += DrawItemBar(_materialItems, y);
            y += DrawItemBar(_legendaryMaterials, y);
            y += DrawItemBar(_otherStuff, y);
        }

        private float DrawItemBar(ISnoItem[] itemsToDisplay, float barY)
        {
            var uiInv = Hud.Inventory.InventoryMainUiElement;

            var rect = new SharpDX.RectangleF(uiInv.Rectangle.Left - 1, barY, uiInv.Rectangle.Width + 2, _materialBackgroundImage.Height * uiInv.Rectangle.Width / _materialBackgroundImage.Width);
            _materialBackgroundImage.Draw(rect.X, rect.Y, rect.Width, rect.Height);

            var itemCountList = new int[itemsToDisplay.Length];
            foreach (var item in Hud.Inventory.GetItemsInStash())
            {
                for (int j = 0; j < itemsToDisplay.Length; j++)
                {
                    if (item.SnoItem == itemsToDisplay[j]) itemCountList[j] += (int)item.Quantity;
                }
            }

            foreach (var item in Hud.Inventory.GetItemsInInventory())
            {
                for (int j = 0; j < itemsToDisplay.Length; j++)
                {
                    if (item.SnoItem == itemsToDisplay[j]) itemCountList[j] += (int)item.Quantity;
                }
            }

            var w = rect.Width / (itemsToDisplay.Length + 1);
            var h = rect.Height * 0.85f;
            var y = rect.Top + (rect.Height - h) / 2;
            for (int i = 0; i < itemsToDisplay.Length; i++)
            {
                var snoItem = itemsToDisplay[i];
                var texture = Hud.Texture.GetItemTexture(snoItem);
                if (texture != null)
                {
                    var x = w / 2 + rect.Left + i * w;
                    texture.Draw(x + w - h, y, h, h, 1);
                    var layout = MaterialCountFont.GetTextLayout(ValueToString(itemCountList[i], ValueFormat.NormalNumberNoDecimal));
                    MaterialCountFont.DrawText(layout, x + w - h * 1.2f - layout.Metrics.Width, y + (h - layout.Metrics.Height) / 2);
                }
            }

            return rect.Height;
        }

    }

}