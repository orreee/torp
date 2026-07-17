using UnityEngine;

public interface IInteractable
{
    public string InteractMessage { get; }
    public string CantInteractMessage { get; }

    public void Interact(GameObject interacting_obj);
    public Requirements[] Needs { get; }
}
