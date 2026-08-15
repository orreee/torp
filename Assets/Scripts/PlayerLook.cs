using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    float max_view = 85.0f;
    float pitch = 0;
    public float sensitivity = 0.1f;
    [SerializeField] InputActionReference look;
    [SerializeField] GameObject view;
    Vector2 lookInput;
    Vector3 rotation;
    CharacterController cc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rotation = new Vector3(0, lookInput.x * sensitivity, 0);

        transform.Rotate(rotation);

        pitch -= lookInput.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -max_view, max_view);
        view.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
