using System;
using Model.InGamePurchase;
using Model.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using View.Item;

namespace View.InGamePurchaseWindow
{
    public class InGamePurchaseWindowView : MonoBehaviour
    {
        public Action<int> OnButtonChangePurchaseClicked;
        public Action OnReceivedButtonClick;

        [SerializeField] private Button nextPurchaseButton;
        [SerializeField] private Button previousPurchaseButton;
        [SerializeField] private Button receivedPurchaseButton;

        [SerializeField] private InGamePurchaseButtonView inGamePurchaseButtonView;
        [SerializeField] private ItemView itemViewPrefab;

        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descriptionText;

        [SerializeField] private Image windowIcon;
        [SerializeField] private Transform itemContainer;

        private ItemView[] _itemsView;

        public void Construct(InGamePurchaseModel purchaseModel)
        {
            Unsubscribe();

            titleText.text = purchaseModel.Title;
            descriptionText.text = purchaseModel.Description;
            windowIcon.sprite = purchaseModel.Icon;

            inGamePurchaseButtonView.Construct(purchaseModel.OldPrice, purchaseModel.NewPrice,
                purchaseModel.DiscountPercent, purchaseModel.PriceFormat,
                purchaseModel.DiscountFormat);
            
            Subscribe();
        }

        private void Subscribe()
        {
            nextPurchaseButton.onClick.AddListener(() => OnButtonChangePurchaseClicked?.Invoke(1));
            previousPurchaseButton.onClick.AddListener(() => OnButtonChangePurchaseClicked?.Invoke(-1));
            receivedPurchaseButton.onClick.AddListener(() => OnReceivedButtonClick?.Invoke());
        }

        private void Unsubscribe()
        {
            nextPurchaseButton.onClick.RemoveAllListeners();
            previousPurchaseButton.onClick.RemoveAllListeners();
            receivedPurchaseButton.onClick.RemoveAllListeners();
        }

        public void CreateItems(ItemModel[] models)
        {
            if (_itemsView != null)
            {
                foreach (var view in _itemsView)
                {
                    if (view != null)
                    {
                        Destroy(view.gameObject);
                    }
                }
            }

            _itemsView = new ItemView[models.Length];

            for (int i = 0; i < _itemsView.Length; i++)
            {
                _itemsView[i] = Instantiate(itemViewPrefab, itemContainer);
                _itemsView[i].Construct(models[i]);
            }
        }
    }
}