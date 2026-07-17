using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    DialogueNodeSO referenceRoot;
    DialogueNode root;
    [SerializeField]
    int id;
    public int ID { get { return id; } }
    private void Start()
    {
        root = new DialogueNode(referenceRoot);
    }
    public DialogueNode GetRoot()
    {
        return root;
    }
    public void AddNode(DialogueNodeSO node, int[] instructions)
    {
        root.AddNode(node, instructions);
    }
}
