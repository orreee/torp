using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    DialogueHandler handler;
    DialogueLibrary library;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        library = GetComponent<DialogueLibrary>();
        handler = GetComponent<DialogueHandler>();
    }
    public void EnterDialogue(DialogueNode dialogue)
    {
        handler.SetDialogue(dialogue);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void LeaveDialogue()
    {

    }
    public void AddNodeTo(int senderID, int toID, DialogueNodeSO node, int[] instructions) => library.AddTo(senderID, toID, node, instructions);
    public void AddNodeTo(int senderID, int toID, DialogueNodeSO node, int[] instructions, string needs) => library.AddToWithCondition(senderID, toID, node, instructions, needs);
    public DialogueNode GetCurrentNode()
    {
        return handler.CurrentNode;
    }
    public Dialogue GetCurrentDialogue()
    {
        return handler.CurrentDialogue;
    }
    public void SetCurrentDialogue(Dialogue dialogue)
    {
        handler.CurrentDialogue = dialogue;
    }
    public void HandleDialogueNode(DialogueNode node)
    {
        handler.Handle(node);
    }
}
