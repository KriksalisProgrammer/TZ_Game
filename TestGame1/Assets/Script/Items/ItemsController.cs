using Assets.Script.Items.Storage;
using UnityEngine;

namespace Assets.Script.Items
{
    public class ItemsController:MonoBehaviour
    {
        private Vector3 itemPositionOffset;
        private StorageItems nextItemStorage;
        private bool isMove = false;

        public ItemType ItemType { get; private set; }
        public static ItemsController Create(ItemType items, Buildings.Buildings creator, StorageItems storage)
        {
            if (!storage.IsCanTakeItem()) return null;

            Transform transform = Instantiate(items.Prefab, creator.transform.position, Quaternion.identity, creator.transform);

            ItemsController item = transform.GetComponent<ItemsController>();
            item.ItemType = items;

            storage.TakeItem(item);

            return item;
        }
        public void Update()
        {
            Vector3 pointToMove = transform.parent.position + itemPositionOffset;
            if (Vector3.Distance(transform.position, pointToMove) > 0.5 && isMove)
            {
                transform.position = Vector3.Lerp(transform.position, pointToMove, Time.deltaTime * 5);
            }
            else
            if (Vector3.Distance(transform.position, pointToMove) < 0.5 && isMove)
            {
                transform.position = pointToMove;

                nextItemStorage.MoveToStorage(this);
                isMove = false;
            }

            if (transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.identity;
            }
        }

        public void SetMove(Transform newParent, StorageItems nextItemStorage, Vector3 itemPositionOffset)
        {

            transform.SetParent(newParent);
            isMove = true;
            this.nextItemStorage = nextItemStorage;
            this.itemPositionOffset = itemPositionOffset;
        }
    }
}
