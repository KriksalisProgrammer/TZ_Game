using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject _playerFollow;
    private Vector3 offset = new Vector3(-0.3f, 11.45f, -10f);
    private void LateUpdate()
    {
        transform.position = _playerFollow.transform.position+offset;
    }
}
