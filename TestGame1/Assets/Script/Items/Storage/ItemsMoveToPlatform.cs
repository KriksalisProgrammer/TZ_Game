using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Items.Storage
{
    public class ItemsMoveToPlatform:ItemsTriger
    {
        public override bool TriggerMove(StorageItems inventory)
        {
            if (inventory.IsCanTakeItem() && _Store.IsCanGiveItem())
            {
                inventory.TakeItem(_Store.GiveItem());
                return true;
            }

            return false;
        }
    }
}
