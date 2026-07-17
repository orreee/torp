using UnityEngine;

public class ItemLogic : MonoBehaviour
{
    [SerializeField]
    GameObject equipped;
    [SerializeField]
    GameObject prop;
    public void Equip(Transform player_pos)
    {
        gameObject.transform.SetParent(player_pos);
        gameObject.transform.SetLocalPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        equipped.SetActive(true);
        prop.SetActive(false);
    }
    public void DeEquip()
    {
        gameObject.transform.SetParent(null);
        prop.SetActive(true);
        equipped.SetActive(false);
    }
}
