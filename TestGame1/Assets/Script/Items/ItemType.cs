using UnityEngine;

namespace Assets.Script.Items
{
    public class ItemType:ScriptableObject
    {
        [SerializeField] private string _nameItem;
        [SerializeField] private Transform _prefab;
        public Transform Prefab
        {
            get
            {
                return _prefab;
            }
        }
    }
}
