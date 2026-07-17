using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    List<CinemachineCamera> cameras;
    Camera main_camera;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        main_camera = FindAnyObjectByType<Camera>();
    }
    public void RegisterCamera(CinemachineCamera camera)
    {
        if(cameras == null)
        {
            cameras = new List<CinemachineCamera>();
        }
        if (camera.gameObject.CompareTag("FirstPersonCamera"))
        {
            GameObject player = FindAnyObjectByType<Player>(FindObjectsInactive.Include).gameObject;
            camera.gameObject.GetComponent<CinemachineCamera>().Target.TrackingTarget = player.GetComponent<CameraPosition>().GetCameraPosition();
        }
        cameras.Add(camera);
    }
    public void MoveHighlightCamera(CameraPosition camera_pos)
    {
        Transform pos = camera_pos.GetCameraPosition();
        foreach(var camera in cameras)
        {
            if (camera.gameObject.CompareTag("HighlightCamera"))
            {
                camera.transform.position = pos.position;
                camera.transform.rotation = pos.rotation;
            }
        }
    }
    public void SwitchCamera()
    {
        foreach(CinemachineCamera camera in cameras)
        {
            camera.gameObject.SetActive(!camera.gameObject.activeSelf);
        }
    }
    public Camera GetMainCamera()
    {
        return main_camera;
    }
}
