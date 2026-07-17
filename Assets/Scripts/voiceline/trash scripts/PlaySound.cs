using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;

    public void Click()
    {
        VoicelineManager.instance.Play(clip);
    }
}