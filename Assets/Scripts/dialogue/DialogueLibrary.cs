using System.Collections.Generic;
using UnityEngine;

public class DialogueLibrary : MonoBehaviour
{
    //this is probably gonna wanna use a json file later to save gamedata, im lazy as fuck rn though
    HashSet<string> records = new();
    Dictionary<string, List<int>> conditionRecords = new();
    public void AddTo(int senderID, int toID, DialogueNodeSO node, int[] instructions)
    {
        string key = $"{node.ID}:{toID}";
        if (!records.Add(key))
        {
            return;
        }
        Debug.Log(senderID + " is adding a node!");
        Get(toID)?.AddNode(node, instructions);
    }
    public void AddToWithCondition(int senderID, int toID, DialogueNodeSO node, int[] instructions, string needs)
    {
        Debug.Log(senderID + " is adding a condition!");
        if (!conditionRecords.ContainsKey(needs))
        {
            conditionRecords.Add(needs, new List<int>());
            conditionRecords[needs].Add(senderID);
            return;
        }
        if (!conditionRecords[needs].Contains(senderID))
        {
            conditionRecords[needs].Add(senderID);
        }
        if(conditionRecords[needs].Count > 1)
        {
            AddTo(senderID, toID, node, instructions);
        }
    }
    public Dialogue Get(int id)
    {
        Dialogue[] dialogues = FindObjectsByType<Dialogue>(FindObjectsInactive.Include);
        foreach(Dialogue dialogue in dialogues)
        {
            if(dialogue.ID == id)
            {
                return dialogue;
            }
        }
        return null;
    }
}
