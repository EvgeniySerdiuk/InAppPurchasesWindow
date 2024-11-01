using System;
using Configs.Item;
using UnityEngine;

namespace Configs.InAppWindow
{
    [Serializable]
    public class ItemPurchase
    {
        [field: SerializeField] public ItemConfig Item { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }

    [CreateAssetMenu(fileName = "InGamePurchaseConfig", menuName = "Configs/InGamePurchase")]
    public class InGamePurchaseConfig : ScriptableObject
    {
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public float Price { get; private set; }
        [field: SerializeField] public string PriceFormat { get; private set; }
        [field: SerializeField] public string DiscountPriceFormat { get; private set; }
        [field: SerializeField, Range(0, 100)] public int DiscountPercent { get; private set; }
        [field: SerializeField] public ItemPurchase[] Items { get; private set; }
    }
}