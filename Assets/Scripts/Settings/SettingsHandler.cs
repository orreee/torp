using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] Slider masterAudioSlider;
    [SerializeField] Slider musicAudioSlider;
    [SerializeField] Slider sfxAudioSlider;
    [SerializeField] GameObject controlsEntryObject;
    [SerializeField] GameObject audioEntryObject;
    [SerializeField] Button[] buttons;
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
        AudioManager.instance.SetVolume(masterAudioSlider.value, musicAudioSlider.value, sfxAudioSlider.value);
    }
    public void OpenAudio()
    {
        Controls.SetActive(false);
        Audio.SetActive(true);
        foreach(Button button in buttons)
        {
            Navigation nav = button.navigation;
            nav.selectOnRight = masterAudioSlider;
            button.navigation = nav;
        }
    }
    public void OpenControls()
    {
        foreach (Button button in buttons)
        {
            Navigation nav = button.navigation;
            nav.selectOnRight = sensitivitySlider;
            button.navigation = nav;
        }
        Controls.SetActive(true);
        Audio.SetActive(false);
    }
}
