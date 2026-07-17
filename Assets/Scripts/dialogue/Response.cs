using TMPro;
using UnityEngine;

public class Response : MonoBehaviour
{
    public DialogueNode node;
    [SerializeField]
    TextMeshProUGUI text;
    public void Set(DialogueNode node)
    {
        this.node = node;
        text.text = node.Response; //This sets the response the player gives the NPC
    }
    public string GetResponse()
    {
        return node.Response; // is this needed?
    }
    public void Click()
    {
        DialogueManager.instance.HandleDialogueNode(node);
    }
}
