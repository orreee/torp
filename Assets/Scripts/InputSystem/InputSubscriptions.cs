using UnityEngine;
using UnityEngine.InputSystem;
public class InputSubscriptions : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public Vector2 LookInput { get; private set; } = Vector2.zero;
    public bool MenuInput { get; private set; } = false;
    public bool InteractInput { get; private set; } = false;
    PlayerControlls _input;

    //private void OnEnable()
    //{
    //    _input = new PlayerControlls();
    //    _input.Player.Enable();
    //    _input.Player.Move.performed += SetMovement;
    //    _input.Player.Move.canceled += SetMovement;
    //    _input.Player.Interact.started += SetInteract;
    //    _input.Player.Interact.canceled += SetInteract;
    //}
    //private void OnDisable()
    //{
    //    _input.Player.Move.performed -= SetMovement;
    //    _input.Player.Move.canceled -= SetMovement;
    //    _input.Player.Interact.started -= SetInteract;
    //    _input.Player.Interact.canceled -= SetInteract;

    //    _input.Player.Disable();
    //}

    //void SetMovement(InputAction.CallbackContext ctx)
    //{
    //    MoveInput = ctx.ReadValue<Vector2>();
    //}

    //void SetInteract(InputAction.CallbackContext ctx)
    //{
    //    InteractInput = ctx.started;
    //}
}
