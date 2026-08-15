using UnityEngine;

public class PauseMainMenuLogic : MonoBehaviour
{
    [SerializeField]
    GameObject EntryObject;
    public void StartButton()
    {
        PauseManager.instance.Pause();
    }
    public GameObject GetEntryObject()
    {
        return EntryObject;
    }
}
