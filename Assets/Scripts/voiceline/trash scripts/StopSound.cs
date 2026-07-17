using UnityEngine;

public class StopSound : MonoBehaviour
{
    public void Click()
    {
        VoicelineManager.instance.Stop();
    }
}
