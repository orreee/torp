using UnityEngine;

public class VoicelineManager : MonoBehaviour
{
    private VoicelinePlayer voiceline_player;
    public static VoicelineManager instance;
    private void Start()
    {
        voiceline_player = GetComponent<VoicelinePlayer>();
        voiceline_player.Init(GetComponent<AudioSource>());
    }
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
    public void Play(AudioClip clip)
    {
        voiceline_player.Play(clip);
    }
    public void Skip()
    {
        voiceline_player.Skip();
    }
    public void Stop()
    {
        voiceline_player.Stop();
    }
}
