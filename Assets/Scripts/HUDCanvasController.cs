using TMPro;
using UnityEngine;

public class HUDCanvasController : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public TextMeshProUGUI GetText()
    {
        return text;
    }
}
