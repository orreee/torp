using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/DialogueScript/ReturnToRoot")]
public class DialogueReturnToRoot : DialogueEvent
{
    public override void Run()
    {
        DialogueManager.instance.HandleDialogueNode(DialogueManager.instance.GetCurrentNode().GetRoot());
    }
}
