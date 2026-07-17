using UnityEngine;

public interface IItem
{
    public string item_name { get; }
    public Requirements[] enables { get; }
    public void Use();
}
