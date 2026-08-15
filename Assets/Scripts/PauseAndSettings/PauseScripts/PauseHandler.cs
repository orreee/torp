using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    Canvas[] oldCanvases;
    Canvas pauseScreen;
    bool paused;
    void Start()
    {
        paused = false;
        SetCanvas();
    }
    #region Pause
    public void Click()
    {
        if (!paused)
        {
            oldCanvases = FindObjectsByType<Canvas>();
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        pauseScreen.gameObject.GetComponent<PauseScreenLogic>().LeaveOrEnter(paused);
        Invert();
        paused = !paused;
    }
    void Invert()
    {
        InvertCanvases();
        InvertPauseScreen();
        InvertTimeScale();
    }
    void SetCanvas()
    {
        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsInactive.Include);
        foreach (Canvas canvas in canvases)
        {
            if(canvas.gameObject.layer == 7)
            {
                pauseScreen = canvas;
                return;
            }
            Debug.LogWarning("Couldn't find PauseScreenCanvas, pauseScreen is null");
        }
    }
    void InvertCanvases()
    {
        foreach(Canvas canvas in oldCanvases)
        {
            bool currentStatus = canvas.gameObject.activeSelf;
            canvas.gameObject.SetActive(!currentStatus);
        }
    }
    void InvertPauseScreen()
    {
        bool currentStatus = pauseScreen.gameObject.activeSelf;
        pauseScreen.gameObject.SetActive(!currentStatus);
    }
    void InvertTimeScale() => Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    #endregion

    #region Settings
    public void ApplySettings(float sensitivity)
    {
        GameObject player = FindAnyObjectByType<Player>(FindObjectsInactive.Include).gameObject;
        player.GetComponent<PlayerLook>().sensitivity = sensitivity;
    }
    #endregion
}
