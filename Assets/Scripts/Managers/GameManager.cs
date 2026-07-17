using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
    }
    public void EnterDialogue(DialogueNode root, GameObject npc)
    {
        //switch which canvas is currently active
        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsInactive.Include);
        for (int i = 0; i < canvases.Length; i++)
        {
            switch (canvases[i].gameObject.layer)
            {
                case 6:
                    canvases[i].gameObject.SetActive(false);
                    break;
                case 5:
                    canvases[i].gameObject.SetActive(true);
                    break;
            }
        }
        // force cameramanager to use scripted instructions to get intended position
        CameraManager.instance.MoveHighlightCamera(npc.GetComponent<CameraPosition>());
        CameraManager.instance.SwitchCamera();
        EnterStopPlayer();
        Cursor.lockState = CursorLockMode.Confined;
        DialogueManager.instance.EnterDialogue(root);
        // Player is stopped
        // Camera focus on the npc
    }
    public void LeaveDialogue()
    {
        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsInactive.Include);
        for (int i = 0; i < canvases.Length; i++)
        {
            switch (canvases[i].gameObject.layer)
            {
                case 6:
                    canvases[i].gameObject.SetActive(true);
                    break;
                case 5:
                    canvases[i].gameObject.SetActive(false);
                    break;
            }
        }
        CameraManager.instance.SwitchCamera();
        LeaveStopPlayer();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public Player GetPlayer()
    {
        return FindAnyObjectByType<Player>(FindObjectsInactive.Include);
    }
    private void EnterStopPlayer()
    {
        GameObject player = FindAnyObjectByType<Player>().gameObject;
        player.SetActive(false);
    }
    private void LeaveStopPlayer()
    {
        GameObject player = FindAnyObjectByType<Player>(FindObjectsInactive.Include).gameObject;
        player.SetActive(true);
    }
}
