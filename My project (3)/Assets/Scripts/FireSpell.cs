using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FireSpell : MonoBehaviour
{
    public int wandType;
    public GameObject fireBallPrefab;
    public GameObject airBallPrefab;
    public GameObject iceBallPrefab;
    public int speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        // Get the name of the magic object
        string objectName = gameObject.name;
        

        // Check the name of the object and set magicType accordingly
        switch (objectName)
        {
            case string name when name.StartsWith("Fire"):
                wandType = 0;
                break;
            case string name when name.StartsWith("Ice"):
                wandType = 1;
                break;
            case string name when name.StartsWith("Wind"):
                wandType = 2;
                break;
            default:
                // Default case if the object name doesn't match any of the cases
                break;
        }

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => Shoot());
    }

    public void Shoot()
    {
        switch (wandType)
        {
            case 0:
                Vector3 fireBallSpawnPosition = transform.position + transform.forward * 0.5f;
                GameObject fireBall = Instantiate(fireBallPrefab, fireBallSpawnPosition, transform.rotation);
                Rigidbody fireBallRigidbody = fireBall.GetComponent<Rigidbody>();
                // Set the velocity of the fireball
                fireBallRigidbody.velocity = transform.forward * speed;
                break;
            case 1:
                Vector3 iceBallSpawnPosition = transform.position + transform.forward * 1f;
                GameObject iceBall = Instantiate(iceBallPrefab, iceBallSpawnPosition, transform.rotation);
                Rigidbody iceBallRigidbody = iceBall.GetComponent<Rigidbody>();
                // Set the velocity of the iceball
                iceBallRigidbody.velocity = transform.forward * speed;
                break;
            case 2:
                Vector3 airBallSpawnPosition = transform.position + transform.up * 1f;
                GameObject airBall = Instantiate(airBallPrefab, airBallSpawnPosition, transform.rotation);
                Rigidbody airBallRigidbody = airBall.GetComponent<Rigidbody>();
                // Set the velocity of the airball
                airBallRigidbody.velocity = transform.up * speed;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
