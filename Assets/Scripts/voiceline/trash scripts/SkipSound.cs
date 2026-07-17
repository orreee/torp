using UnityEngine;

public class SkipSound : MonoBehaviour
{
    public void Click()
    {
        VoicelineManager.instance.Skip();
    }
}
