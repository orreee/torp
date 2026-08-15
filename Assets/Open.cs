using UnityEngine;

public class Open : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string InteractMessage { get { return interactMessage; } }

    public string CantInteractMessage { get { return cantInteractMessage; } }

    public GameObject player;

    public GameObject coordinates;

    [SerializeField]
    protected string interactMessage = "Open";
    protected string cantInteractMessage = string.Empty;

    public Requirements[] Needs { get { return array; } }
    private Requirements[] array = new Requirements[0];

    public virtual void Interact(GameObject other)
    {
        player.transform.rotation = coordinates.transform.rotation;
        CharacterController temp = player.GetComponent<CharacterController>();
        temp.enabled = false;
        player.transform.position = coordinates.transform.position; //character controller would have ignored this
        temp.enabled = true;
    }

}
