using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void SendValue(float value)
    {
        PauseManager.instance.ApplySettings(value);
    }
    public void DumbSendValue()
    {
        PauseManager.instance.ApplySettings(slider.value);
    }
}
