using Assets.Script.Items.Storage;
using UnityEngine;

public class ItemsTriger : MonoBehaviour
{
    private float _TimeToNext = 0;

    [SerializeField]private float _time = 5;

    [SerializeField]protected StorageItems _Store;

    private void OnTriggerStay(Collider other)
    {
        StorageItems inventory = other.GetComponent<StorageItems>();
        if (inventory)
        {
            _TimeToNext += Time.deltaTime;
            if (_TimeToNext > _time)
                if (TriggerMove(inventory))
                    _TimeToNext = 0;
        }
    }

    public virtual bool TriggerMove(StorageItems inventory)
    {
        return false;
    }
}
