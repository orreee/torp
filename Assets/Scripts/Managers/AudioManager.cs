using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private Bus masterBus;
    private Bus musicBus;
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
        SetBuses();
    }
    void SetBuses()
    {
        masterBus = RuntimeManager.GetBus("bus:/");
        //musicBus = RuntimeManager.GetBus("bus:/Music");
    }
    public void SetVolume(float master, float music)
    {
        masterBus.setVolume(master);
        //musicBus.setVolume(music);
    }
}
