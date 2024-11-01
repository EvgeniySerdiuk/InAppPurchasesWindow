using UnityEngine;

namespace Configs.Item
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Item")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}