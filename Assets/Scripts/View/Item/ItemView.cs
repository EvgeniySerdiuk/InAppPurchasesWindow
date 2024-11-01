using Model.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.Item
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text counterText;

        public void Construct(ItemModel itemModel)
        {
            itemImage.sprite = itemModel.Sprite;
            itemName.text = itemModel.Name;
            counterText.text = itemModel.Amount.ToString();
        }
    }
}