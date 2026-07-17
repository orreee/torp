using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float default_speed = 5.0f;
    Rigidbody rb;
    Vector3 move_dir;
    [SerializeField] InputActionReference move;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = speed == 0 ? default_speed : speed;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        move_dir = move.action.ReadValue<Vector2>();
    }

    private void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
    }

    void FixedUpdate()
    {
        Vector3 dir = (transform.right * move_dir.x + transform.forward * move_dir.y) * speed;
        rb.linearVelocity = new Vector3(dir.x, rb.linearVelocity.y, dir.z);
    }
}
