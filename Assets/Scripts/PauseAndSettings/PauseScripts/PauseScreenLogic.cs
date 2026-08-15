using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseScreenLogic : MonoBehaviour
{
    [SerializeField]
    EventSystem _eventSystem;
    [SerializeField]
    GameObject MainMenu;
    [SerializeField]
    GameObject SettingsMenu;
    [SerializeField]
    GameObject entryObject;
    public void LeaveOrEnter(bool paused)
    {
        if (!paused)
        {
            Enter();
        }
        else
        {
            Leave();
        }
    }
    void Enter()
    {
        _eventSystem.SetSelectedGameObject(entryObject);
    }
    void Leave()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
    public void SelectSettings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        SettingsMenu.GetComponent<SettingsHandler>().Enter(_eventSystem);
    }
    public void SelectMainMenu()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        _eventSystem.SetSelectedGameObject(entryObject);
    }
}
