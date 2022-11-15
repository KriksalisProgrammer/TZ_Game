using UnityEngine;

namespace Assets.Script.Items.Storage
{
    public class ItemStoragePlayer:StorageItems
    {
        protected override Vector3 ItemPositionOffset(int intemCount)
        {
            return new Vector3(0, intemCount, 0);
        }
    }
}
