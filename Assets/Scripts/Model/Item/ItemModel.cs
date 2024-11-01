using Configs.Item;
using UnityEngine;

namespace Model.Item
{
    public class ItemModel
    {
        public string Name => _config.Name;
        public Sprite Sprite => _config.Sprite;
        public int Amount { get; private set; }

        private readonly ItemConfig _config;

        public ItemModel(ItemConfig config, int amount = 1)
        {
            _config = config;
            Amount = amount;
        }

        public void ReceivedItems()
        {
            Debug.Log($"<color=green>Итем: {Name}</color>\nКоличество: {Amount}");
            Amount = 0;
        }
    }
}