using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Player : MonoBehaviour
{
    HashSet<Requirements> has;
    private void Start()
    {
        has = new();
    }
    public void Add(Requirements requirement)
    {
        has.Add(requirement);
    }
    public void Add(Requirements[] requirements)
    {
        for (int i = 0; i < requirements.Length; i++)
        {
            has.Add(requirements[i]);
        }
    }
    public bool CheckRequirements(Requirements[] requirements)
    {
        if (requirements.Length == 0) { return true; }
        if(has.Count == 0) { return false; }

        for (int i = 0; i < requirements.Length; i++)
        {
            if (!has.Contains(requirements[i]))
            {
                return false;
            }
        }
        return true;
    }
}
