using UnityEngine;
using UnityEngine.InputSystem;

public class SpearController : MonoBehaviour
{

    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        // Handle collision with target or environment
        Debug.Log("Spear hit something!");
    }
}