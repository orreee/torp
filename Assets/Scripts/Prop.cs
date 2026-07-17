using UnityEngine;

public interface Prop : IInteractable
{
    public string prop_name { get; }
    public Requirements[] enables { get; }
}
