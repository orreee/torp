using UnityEngine;

public class DialogueNode
{
    string[] text;
    float[] timers;
    DialogueNode[] children;
    DialogueNode parent;
    string response;
    public string[] Text { get { return text; } }
    public float[] TextTimers { get { return timers; } }
    public string Response { get { return response; } }
    public DialogueNode[] Children { get { return children; } }
    public DialogueNode Parent { set { parent = value; } }
    DialogueEvent[] script;
    public DialogueEvent[] Script { get { return script; } }
    public DialogueNode()
    {

    }
    public DialogueNode(DialogueNodeSO node)
    {
        InitNode(node);
    }

    public DialogueNode(DialogueNodeSO node, DialogueNode parent)
    {
        this.parent = parent;
        InitNode(node);
    }
    public void InitNode(DialogueNodeSO node)
    {
        InitTexts(node.Text);
        InitTextTimers(node.TextTimers);
        InitScript(node.script);
        InitResponse(node.Response);
        if (node.Children != null && node.Children.Length > 0)
        {
            InitChildren(node.Children);
        }
    }
    #region initialize
    void InitTexts(string[] text) => this.text = text;
    void InitTextTimers(float[] timers) => this.timers = timers;
    void InitScript(DialogueEvent[] script) => this.script = script;
    void InitResponse(string response) => this.response = response;
    void InitChildren(DialogueNodeSO[] children)
    {
        this.children = new DialogueNode[children.Length];
        for (int i = 0; i < children.Length; i++)
        {
            this.children[i] = new DialogueNode(children[i], this);
        }
    }
    #endregion initialize
    public DialogueNode GetRoot()
    {
        if(parent != null)
        {
            return parent.GetRoot();
        }
        return this;
    }
    public void AddNode(DialogueNodeSO node, int[] instructions)
    {
        //forgive me lord.
        if (instructions.Length > 0)
        {
            for (int i = 0; i < children.Length; i++)
            {
                if (i + 1 == instructions[0])
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
            DialogueNode[] newArray = new DialogueNode[children.Length + 1];
            for (int i = 0; i < children.Length; i++)
            {
                newArray[i] = children[i];
            }
            DialogueNode newNode = new DialogueNode(node, this);
            newArray[newArray.Length - 1] = newNode; //put new node at very end
            children = newArray;
        }
        return;
    }
}
