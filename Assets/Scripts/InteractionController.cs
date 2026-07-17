using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    Camera player_camera;

    [SerializeField]
    TextMeshProUGUI interaction_text;

    [SerializeField]
    float interaction_distance = 5f;

    IInteractable current_targeted_interactable;

    bool able = false;

    private void Start()
    {
        if(player_camera == null)
        {
            player_camera = CameraManager.instance.GetMainCamera();
        }
        if (interaction_text == null)
        {
            interaction_text = FindAnyObjectByType<HUDCanvasController>().GetText();
        }
    }

    public void Update()
    {
        UpdateCurrentInteractable();

        CheckRequirements();

        UpdateInteractionText();

        CheckForInteractionInput();
    }

    void UpdateCurrentInteractable()
    {
        var ray = player_camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        Physics.Raycast(ray, out var hit, interaction_distance);
        current_targeted_interactable = hit.collider?.GetComponent<IInteractable>();
    }

    void UpdateInteractionText()
    {
        if(current_targeted_interactable == null)
        {
            interaction_text.text = string.Empty;
            return;
        }
        switch (able)
        {
            case true:
                interaction_text.text = current_targeted_interactable.InteractMessage;
                break;
            case false:
                interaction_text.text = current_targeted_interactable.CantInteractMessage;
                break;
        }
    }

    void CheckRequirements()
    {
        if (current_targeted_interactable == null)
        {
            return;
        }
        able = gameObject.GetComponent<Player>().CheckRequirements(current_targeted_interactable.Needs);
    }

    void CheckForInteractionInput()
    {
        if(current_targeted_interactable == null)
        {
            return;
        }
        if (Keyboard.current.eKey.wasPressedThisFrame && able)
        {
            current_targeted_interactable.Interact(gameObject);
        }
    }
}
