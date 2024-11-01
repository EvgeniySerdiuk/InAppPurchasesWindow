using UnityEngine;
using UnityEngine.UI;

namespace CustomComponent
{
    public class CustomGridLayout : GridLayoutGroup
    {
        public override void SetLayoutVertical()
        {
            base.SetLayoutVertical();
            CenterItems();
        }

        private void CenterItems()
        {
            int columns = constraintCount;
            int itemCount = rectChildren.Count;

            if (itemCount <= columns) return;

            int fullRows = itemCount / columns;
            int remainingItems = itemCount % columns;

            if (remainingItems > 0)
            {
                float offset = (columns - remainingItems) * (cellSize.x + spacing.x) / 2;

                for (int i = fullRows * columns; i < itemCount; i++)
                {
                    var item = rectChildren[i];
                    item.anchoredPosition += new Vector2(offset, 0);
                }
            }
        }
    }
}