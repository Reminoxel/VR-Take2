using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBehavior : MonoBehaviour
{
    private int magicType;
    private int damage = 1;
    private Coroutine damageOverTimeCoroutine;
    private Coroutine freezeCoroutine;
    private float pushForce = 5f;


    // Start is called before the first frame update
    void Start()
    {
        // Get the name of the magic object
        string objectName = gameObject.name;

        // Check the name of the object and set magicType accordingly
        switch (objectName)
        {
            case string name when name.StartsWith("Fireball"):
                magicType = 0;
                break;
            case string name when name.StartsWith("Iceball"):
                magicType = 1;
                break;
            case string name when name.StartsWith("Airball"):
                magicType = 2;
                break;
            default:
                // Default case if the object name doesn't match any of the cases
                Debug.LogWarning("Unknown magic type!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if collided with an object tagged as "Environment" or "Enemy"
        if (collision.gameObject.CompareTag("Environment") || collision.gameObject.CompareTag("Enemy"))
        {
            // Check for nearby objects tagged as "Enemy" within a radius of 3 units
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    EnemyController enemyController = col.GetComponent<EnemyController>();
                    if (enemyController != null)
                    {
                        // Apply damage to the enemy's health
                        enemyController.health -= damage;

                        // Apply type effects
                        switch (magicType)
                        {
                            case 0: // Fireball
                                damageOverTimeCoroutine = StartCoroutine(enemyController.DamageOverTime());
                                break;
                            case 1: // Iceball
                                freezeCoroutine = StartCoroutine(enemyController.Freeze());
                                break;
                            case 2: // Airball
                                Rigidbody enemyRB = col.GetComponent<Rigidbody>();
                                if (enemyRB != null)
                                {
                                    Vector3 pushDirection = col.transform.position - transform.position;
                                    pushDirection.y = 0; // Ensure no vertical push
                                    pushDirection.Normalize();
                                    enemyRB.AddForce(pushDirection * pushForce, ForceMode.Impulse);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    return;
                }
            }
            Destroy(gameObject);
        }
    }
}
