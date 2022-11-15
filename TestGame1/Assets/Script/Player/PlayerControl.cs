using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float gravityForce;

    private Vector3 moveVector;
    private CharacterController characterController;
    private float currentAttractionCharacter = 0;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        CharacterMove();
    }
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = _joystick.Horizontal * _speed;
        moveVector.y = currentAttractionCharacter;
        moveVector.z = _joystick.Vertical * _speed;

        if(Vector3.Angle(Vector3.forward,moveVector)>1f|| Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, _speed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        characterController.Move(moveVector * Time.deltaTime);
    }
}
