using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] Slider masterAudioSlider;
    [SerializeField] Slider musicAudioSlider;
    [SerializeField] GameObject controlsEntryObject;
    [SerializeField] GameObject audioEntryObject;
    [SerializeField]
    GameObject Controls;
    [SerializeField]
    GameObject Audio;
    public void Enter(EventSystem eventSystem)
    {
        eventSystem.SetSelectedGameObject(controlsEntryObject);
        OpenControls();
    }
    public void SendValue(float value)
    {
        PauseManager.instance.ApplySettings(value);
    }
    public void DumbSendValue()
    {
        PauseManager.instance.ApplySettings(sensitivitySlider.value);
        AudioManager.instance.SetVolume(masterAudioSlider.value, musicAudioSlider.value);
    }
    public void OpenAudio()
    {
        Controls.SetActive(false);
        Audio.SetActive(true);
    }
    public void OpenControls()
    {
        Controls.SetActive(true);
        Audio.SetActive(false);
    }
}
