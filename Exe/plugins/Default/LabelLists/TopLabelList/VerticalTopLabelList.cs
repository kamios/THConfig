namespace Turbo.Plugins.Default
{

    public class VerticalTopLabelList : AbstractTopLabelList
    {

        public VerticalTopLabelList(IController hud)
            : base(hud)
        {
        }

        protected override void Paint(float x, float y, float labelWidth, float labelHeight)
        {
            foreach (var label in LabelDecorators)
            {
                label.Paint(x, y, labelWidth, labelHeight, HorizontalAlign.Center);
                y += labelHeight + SpacingAdjustmentInPixels;
            }
        }

    }

}