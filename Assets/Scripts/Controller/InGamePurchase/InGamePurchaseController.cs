using System.Linq;
using Configs.InAppWindow;
using Model.InGamePurchase;
using UnityEngine;
using UnityEngine.UI;
using View.InGamePurchaseWindow;

namespace Controller.InGamePurchase
{
    public class InGamePurchaseController : MonoBehaviour
    {
        [SerializeField] private Transform windowContainer;
        [SerializeField] private InGamePurchaseWindowView purchaseWindowView;
        [SerializeField] private Button openPurchaseButton;
        [SerializeField] private InGamePurchaseConfig[] purchaseConfigs;

        private InGamePurchaseWindowView _inGamePurchaseWindowView;
        
        private InGamePurchaseModel[] _purchaseModels;
        private InGamePurchaseModel _currentModel => _purchaseModels[_indexCurrentModel];
        
        private int _indexCurrentModel = 0;

        private void Awake()
        {
            _purchaseModels = purchaseConfigs.Select(x => new InGamePurchaseModel(x)).ToArray();
            openPurchaseButton.onClick.AddListener(CreatePurchaseView);
        }

        private void CreatePurchaseView()
        {
            openPurchaseButton.onClick.RemoveListener(CreatePurchaseView);

            _inGamePurchaseWindowView = Instantiate(purchaseWindowView, windowContainer);
            _inGamePurchaseWindowView.Construct(_currentModel);
            _inGamePurchaseWindowView.CreateItems(_currentModel.Items);

            _inGamePurchaseWindowView.OnButtonChangePurchaseClicked += ChangePurchaseModel;
            _inGamePurchaseWindowView.OnReceivedButtonClick += ReceivedItems;
        }

        private void ChangePurchaseModel(int value)
        {
            _indexCurrentModel = (_indexCurrentModel + value) % _purchaseModels.Length;

            if (_indexCurrentModel < 0)
            {
                _indexCurrentModel += _purchaseModels.Length;
            }

            _inGamePurchaseWindowView.Construct(_currentModel);
            _inGamePurchaseWindowView.CreateItems(_currentModel.Items);
        }

        private void ReceivedItems()
        {
            var receivedItems = _currentModel.Items;

            Debug.Log("Получено:");

            foreach (var item in receivedItems)
            {
                item.ReceivedItems();
            }
        }
    }
}