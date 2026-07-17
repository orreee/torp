using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/DialogueScript/AddDialogueNodeConditional")]
public class AddDialogueWithCondition : DialogueEvent
{
    [SerializeField]
    int[] instructions;
    [SerializeField]
    DialogueNodeSO node;
    [SerializeField]
    int toID;
    [SerializeField]
    string needsKey;
    public override void Run()
    {
        int senderID = DialogueManager.instance.GetCurrentDialogue().ID;
        DialogueManager.instance.AddNodeTo(senderID, toID, node, instructions, needsKey);
    }
}
