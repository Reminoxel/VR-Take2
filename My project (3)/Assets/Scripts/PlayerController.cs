using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayerController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private XRDirectInteractor directInteractor;

    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        directInteractor = GetComponent<XRDirectInteractor>();

        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);

        currentHealth = maxHealth;
    }

    void Update()
    {
    }

    void OnGrab(XRBaseInteractor interactor)
    {
       
    }

    void OnRelease(XRBaseInteractor interactor)
    {
    }

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            GameOver();
        }
        else
        {
            //debug message for now 
            Debug.Log("Player Hit! Remaining Hearts: " + currentHealth);

        }
    }

    void GameOver()
    {
       //debug message for now 
        Debug.Log("Game Over");
    }
}
