using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;
    PauseHandler handler;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        handler = GetComponent<PauseHandler>();
    }
    public void Pause()
    {
        handler.Click();
    }
    public void ApplySettings(float sensitivity)
    {
        handler.ApplySettings(sensitivity);
    }
}
