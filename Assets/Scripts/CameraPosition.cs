using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField]
    Transform cameraPosition;
    public Transform GetCameraPosition()
    {
        return cameraPosition;
    }
}
