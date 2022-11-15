using Assets.Script.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Buildings
{
    public class BuildType:ScriptableObject
    {
        [SerializeField] private Transform _prefabBuilding;

        [SerializeField] private ItemType _productionItem;

        [SerializeField] private float _timer;

        [SerializeField] private List<ItemType> _needItems;

        public ItemType Product
        {
            get
            {
                return _productionItem;
            }
        }

        public float TimeToProduct
        {
            get
            {
                return _timer;
            }
        }

        public List<ItemType> needToProductionItems
        {
            get
            {
                return _needItems;
            }
        }
    }
}
