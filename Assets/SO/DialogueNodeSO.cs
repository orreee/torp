using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueNode", order = 1)]
public class DialogueNodeSO : ScriptableObject
{
    public string Response;
    public string[] Text;
    public float[] TextTimers;
    public DialogueNodeSO[] Children { get { return children; } }
    [SerializeField]
    DialogueNodeSO[] children;
    [SerializeReference]
    public DialogueEvent[] script;
    [SerializeField]
    int id;
    public int ID { get { return id; } }
    public void AddNode(DialogueNodeSO node, int[] instructions)
    {
        //forgive me lord.
        if(instructions.Length > 0)
        {
            for (int i = 0; i < children.Length; i++)
            {
                if(i + 1 == instructions[0])
                {
                    int[] newInstructions = new int[instructions.Length - 1];
                    for (int j = 0; j < newInstructions.Length; j++)
                    {
                        newInstructions[j] = instructions[j + 1];
                    }
                    children[i].AddNode(node, newInstructions);
                    return;
                }
            }
        }
        else
        {
            DialogueNodeSO[] newArray = new DialogueNodeSO[children.Length + 1];
            for (int i = 0; i < children.Length; i++)
            {
                newArray[i] = children[i];
            }
            newArray[newArray.Length - 1] = node; //put new node at very end
            children = newArray;
        }
        return;
    }
}