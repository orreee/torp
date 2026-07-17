using UnityEngine;
using System.Collections.Generic;

public class FixerDixerScript : MonoBehaviour
{
    [SerializeField]
    DialogueNodeSO node;
    [SerializeField]
    DialogueNodeSO otherNode;
    List<string> names;
    public void Run(DialogueNodeSO node, int[] instructions)
    {
        this.node.AddNode(node, instructions);
    }
    public void Run(DialogueNodeSO node, int[] instructions, string name)
    {
        if(names == null) { names = new List<string>(); }
        else if (names.Contains(name)) { return; }
        names.Add(name);
        if(names.Count >= 2)
        {
            otherNode.AddNode(node, instructions);
        }
    }
}
