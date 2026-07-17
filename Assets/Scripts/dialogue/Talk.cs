using UnityEngine;

public class Talk : MonoBehaviour, IInteractable
{
    public string InteractMessage { get { return interactMessage; } }

    public string CantInteractMessage { get { return cantInteractMessage; } }

    [SerializeField]
    protected string interactMessage = "Talk";
    protected string cantInteractMessage = string.Empty;

    public Requirements[] Needs {  get { return array; } }
    private Requirements[] array = new Requirements[0];

    public DialogueNode GetRoot()
    {
        return GetComponent<Dialogue>().GetRoot();
    }

    public virtual void Interact(GameObject other)
    {
        DialogueManager.instance.SetCurrentDialogue(GetComponent<Dialogue>());
        GameManager.instance.EnterDialogue(GetRoot(), gameObject);
    }
}
