using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/DialogueScript/GivePlayerRequirement")]
public class GivePlayerRequirement : DialogueEvent
{
    [SerializeField]
    Requirements[] give;
    public override void Run()
    {
        if(give.Length == 0) { return; }

        GameManager.instance.GetPlayer().Add(give);
    }
}
