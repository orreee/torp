using Unity.Cinemachine;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField]
    public bool activeOnStart;
    private void Start()
    {
        CameraManager.instance.RegisterCamera(GetComponent<CinemachineCamera>());
        gameObject.SetActive(activeOnStart);
    }
}
