namespace Turbo.Plugins.Default
{

    public class HorizontalTopLabelList : AbstractTopLabelList
    {

        public HorizontalTopLabelList(IController hud)
            : base(hud)
        {
        }

        protected override void Paint(float x, float y, float labelWidth, float labelHeight)
        {
            foreach (var label in LabelDecorators)
            {
                label.Paint(x, y, labelWidth, labelHeight, HorizontalAlign.Center);
                x += labelWidth + SpacingAdjustmentInPixels;
            }
        }

    }

}