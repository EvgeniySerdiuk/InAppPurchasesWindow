using System.Linq;
using Configs.InAppWindow;
using Model.Item;
using UnityEngine;

namespace Model.InGamePurchase
{
    public class InGamePurchaseModel
    {
        public readonly string Title;
        public readonly string Description;
        public readonly Sprite Icon;
        public readonly string PriceFormat;
        public readonly string DiscountFormat;
        public readonly int DiscountPercent;
        public readonly float OldPrice;
        public readonly float NewPrice;

        public ItemModel[] Items { get; private set; }

        public InGamePurchaseModel(InGamePurchaseConfig config)
        {
            Items = config.Items.Select(x => new ItemModel(x.Item, x.Amount)).ToArray();
            Title = config.Title;
            Description = config.Description;
            Icon = config.Icon;
            PriceFormat = config.PriceFormat;
            DiscountFormat = config.DiscountPriceFormat;
            DiscountPercent = config.DiscountPercent;
            OldPrice = config.Price;
            NewPrice = config.Price * (1 - DiscountPercent / 100f);
        }
    }
}