using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public string InteractMessage { get { return interactMessage; } }
    string interactMessage = "Open Door";

    public string CantInteractMessage { get { return cantInteractMessage; } }
    string cantInteractMessage = "Locked";

    public Requirements[] Needs { get { return array; } }
    Requirements[] array = new Requirements[] { Requirements.Key };

    public void Interact(GameObject interacting_obj)
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(2);
    }
}
