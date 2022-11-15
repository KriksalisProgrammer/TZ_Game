using UnityEngine;
using System.Collections.Generic;
using Assets.Script.Items;
using Assets.Script.Items.Storage;

namespace Assets.Script.Buildings
{
    public class Buildings : MonoBehaviour
    {
        [SerializeField] private BuildType _buildingType;

        [SerializeField] private StorageItems _storageToCreatedItems;

        [SerializeField] private StorageItems _storageToNeededItems;

        [SerializeField] private ItemsStorageInBuilding _storageInBuilding;

        private float _timeProduct= 0;

        private bool _IsProd = false;
        private bool _isProductionTime = false;
        private bool IsThereNeededItems()
        {
            foreach (ItemType itemType in _buildingType.needToProductionItems)
            {
                if (!_storageToNeededItems.IsCanGiveItem(itemType))
                {
                    return false;
                }
            }
            return true;
        }
      

        private void MoveNeededItems()
        {
            foreach (ItemType itemType in _buildingType.needToProductionItems)
            {
                _storageInBuilding.TakeItem(_storageToNeededItems.GiveItem(itemType));
            }
        }

        private void Update()
        {

            if (!_IsProd && !_isProductionTime)
            {
                if (IsThereNeededItems())
                {
                    MoveNeededItems();
                    _isProductionTime = true;
                }
                else
                {

                    string text = "В здании " + _buildingType.name + " нет нужных предметов на складе";
                    if (!Message.instance._message.Contains(text))
                    {
                        Message.instance._message.Add(text);
                    }
                }
            }

            if (!_IsProd && _isProductionTime)
            {
                if (_storageInBuilding.IsCompleteMove(_buildingType.needToProductionItems))
                {
                    _storageInBuilding.DestroyAllItems();
                    _IsProd = true;
                    _isProductionTime = false;
                }
            }

            if (_IsProd)
            {
                if (_storageToCreatedItems.IsCanTakeItem())
                {
                    _timeProduct += Time.deltaTime;
                    if (_timeProduct > _buildingType.TimeToProduct)
                    {
                        ItemsController.Create(_buildingType.Product, this, _storageToCreatedItems);
                        _timeProduct = 0;
                        _IsProd = false;
                        _isProductionTime = false;
                    }
                }
                else
                {

                    string text = "В здании " + _buildingType.name + " склад заполнен продукцией";
                    if (!Message.instance._message.Contains(text))
                    {
                        Message.instance._message.Add(text);

                    }
                }

            }

        }
    }
}
