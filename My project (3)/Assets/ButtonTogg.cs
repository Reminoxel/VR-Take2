using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObject : MonoBehaviour
{
    [SerializeField] private GameObject targetGameObject;
    [SerializeField] private Button toggleButton;

    private void Start()
    {
        // Add listener to the button click event
        toggleButton.onClick.AddListener(ToggleGameObjectActiveState);
    }

    private void ToggleGameObjectActiveState()
    {
        // Toggle the active state of the target game object
        targetGameObject.SetActive(!targetGameObject.activeSelf);
    }
}
