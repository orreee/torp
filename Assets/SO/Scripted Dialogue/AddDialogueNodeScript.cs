using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/DialogueScript/AddDialogueNode")]
public class AddDialogueNodeScript : DialogueEvent
{
    [SerializeField]
    int[] instructions;
    [SerializeField]
    DialogueNodeSO node;
    [SerializeField]
    int toID;
    public override void Run()
    {
        int senderID = DialogueManager.instance.GetCurrentDialogue().ID;
        DialogueManager.instance.AddNodeTo(senderID, toID, node, instructions);
    }
}
