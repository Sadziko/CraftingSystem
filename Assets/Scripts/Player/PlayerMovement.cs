using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [Header("Config")]
    [SerializeField] float moveSpeed = 5f;

    Vector3 moveDir;

    private void Awake()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();
    }

    public void OnMove(CallbackContext callbackContext)
    {
        moveDir = InputVectorToMoveVector(callbackContext.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {
        characterController.Move(moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    private Vector3 InputVectorToMoveVector(Vector2 inputVector)
    {
        return new Vector3(inputVector.x, 0, inputVector.y);
    }
}
