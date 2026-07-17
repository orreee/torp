using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float speed;
    float default_speed = 5.0f;
    float max_view = 85.0f;
    float pitch = 0;
    public float sensitivity = 0.1f;
    [SerializeField] InputActionReference look;
    [SerializeField] GameObject view;
    Vector2 look_dir;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = speed == 0 ? default_speed : speed;
    }

    // Update is called once per frame
    void Update()
    {
        look_dir = look.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        float rotation_y = rb.rotation.eulerAngles.y;
        rotation_y += look_dir.x * sensitivity;
        rb.MoveRotation(Quaternion.Euler(rb.rotation.eulerAngles.x, rotation_y, rb.rotation.eulerAngles.z));

        pitch -= look_dir.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -max_view, max_view);
        view.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
