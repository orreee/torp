using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float default_speed = 5.0f;
    float gravity = -9.82f;
    Rigidbody rb;
    CharacterController cc;
    Vector2 moveInput;
    public Vector3 velocity;
    //[SerializeField] InputActionReference move;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        speed = speed == 0 ? default_speed : speed;
        Init();
    }

    private void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        cc.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        if (cc.isGrounded)
        {
            velocity.y = 0;
        }
    }
}
