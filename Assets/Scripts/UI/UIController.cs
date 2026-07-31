using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    public void OnPause(InputAction.CallbackContext ctx)
    {
        PauseManager.instance.Pause();
    }
}
