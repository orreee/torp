using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    DialogueNode root;
    DialogueNode current_node;
    public DialogueNode CurrentNode { get { return current_node; } }
    Dialogue currentDialogue;
    public Dialogue CurrentDialogue { get { return currentDialogue; } set { currentDialogue = value; } }
    [SerializeField]
    Canvas dialogue_canvas;
    [SerializeField]
    TextMeshProUGUI npc_text;
    [SerializeField]
    GameObject response_list;
    [SerializeField]
    GameObject response_prefab;
    private void Start()
    {

    }
    public void SetDialogue(DialogueNode parent)
    {
        root = parent;
        Handle(root);
    }
    public void Handle(DialogueNode node)
    {
        current_node = node;
        ClearResponseList();
        StartCoroutine(Processing(current_node.Text, current_node.TextTimers));
        //WriteText(current_node.Text);
    }
    void HandleResponseAndLogic()
    {
        AddResponse(current_node.Children);
        CheckScript(current_node);
    }
    void CheckScript(DialogueNode node)
    {
        for(int i = 0; i < node.Script.Length; i++)
        {
            node.Script[i].Run();
        }
    }
    void WriteText(string text)
    {
        npc_text.text = text;
    }
    void AddResponse(DialogueNode[] nodes)
    {
        if(nodes == null)
        {
            return;
        }
        for (int i = 0; i < nodes.Length; i++)
        {
            GameObject response = Instantiate(response_prefab, Vector3.zero, Quaternion.identity, response_list.transform); // create empty response
            response.GetComponent<Response>().Set(nodes[i]);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(response_list.GetComponent<RectTransform>());
    }
    void ClearResponseList()
    {
        foreach (Transform child in response_list.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private IEnumerator Processing(string[] strings, float[] timers)
    {
        if(strings.Length != timers.Length && !(strings.Length == 1 && timers.Length == 0))
        {
            Debug.LogWarning("Major fuckup here");
        }
        for(int i = 0; i < strings.Length; i++)
        {
            WriteText(strings[i]);
            if(timers.Length == 0)
            {
                break;
            }
            yield return new WaitForSeconds(timers[i]);
        }
        HandleResponseAndLogic();
        yield return null;
    }
}
