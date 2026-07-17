using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/DialogueScript/DefaultExitEvent")]
public class DefaultExitEvent : DialogueEvent
{
    public override void Run()
    {
        GameManager.instance.LeaveDialogue();
    }
}
