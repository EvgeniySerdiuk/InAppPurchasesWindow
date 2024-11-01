using System.Text;
using TMPro;
using UnityEngine;

namespace View.InGamePurchaseWindow
{
    public class InGamePurchaseButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text buttonText;
        [SerializeField] private TMP_Text discountText;
        [SerializeField] private CanvasGroup discountIconCanvasGroup;

        public void Construct(float price, float priceWithDiscount, int discount, string priceStyle,
            string discountStyle)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (discount > 0)
            {
                discountText.text = discount.ToString();
                stringBuilder.AppendFormat(priceStyle, priceWithDiscount.ToString("F2"));
                stringBuilder.AppendLine();
                stringBuilder.AppendFormat(discountStyle, price.ToString("F2"));
            }
            else
            {
                stringBuilder.AppendFormat(priceStyle, price);
            }

            discountIconCanvasGroup.alpha = discount > 0 ? 1f : 0f;
            buttonText.text = stringBuilder.ToString();
        }
    }
}