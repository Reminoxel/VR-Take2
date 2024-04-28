using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int enemyType;
    public int health;
    private Coroutine damageOverTimeCoroutine;
    private Coroutine freezeCoroutine;
    private GameObject self;
    private GameObject tower;
    private Rigidbody selfRB;
    private float moveSpeed;
    bool atTower;
    float towerDistance;
    private bool isFrozen = false;
    private int damage;

    void Start()
    {
        self = gameObject;
        selfRB = self.GetComponent<Rigidbody>();
        tower = GameObject.Find("Tower");
        atTower = false;

        switch (self.name) {
            case string s when s.StartsWith("NormalEnemy"):
                enemyType = 1;
                health = 1;
                break;
            case string s when s.StartsWith("FlyingEnemy"):
                enemyType = 2;
                health = 4;
                break;
            case string s when s.StartsWith("HeavyEnemy"):
                enemyType = 3;
                health = 10;
                break;
            default:
                break;
        }
        UpdateType();
    }

    void UpdateType()
    {
        switch (enemyType)
        {
            case 1: // Basic Enemy
                moveSpeed = 4f;
                health = 1;
                damage = 1;
                break;
            case 2: // Flying Enemy
                moveSpeed = 6f;
                health = 3;
                damage = 10;
                break;
            case 3: // Heavy Enemy
                moveSpeed = 3f;
                health = 15;
                damage = 5;
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        towerDistance = Vector3.Distance(tower.transform.position, self.transform.position);
        transform.LookAt(tower.transform);
        if (towerDistance < 5.0f)
        {
            atTower = true;
            // Flying enemy exploading
            if (enemyType == 2)
            {
                // Damage tower


                Destroy(gameObject);
            }

            // Start attacking tower


        } else {
            atTower = false;
        }

        if (atTower == false)
        {
            if (isFrozen == false)
            {
                selfRB.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator DamageOverTime()
    {
        // Change color filter to red
        Renderer renderer = GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        renderer.material.color = Color.red;

        // Apply damage over time
        int damageCount = 0;
        while (damageCount <= 2)
        {
            // Apply damage over time
            health--;
            damageCount++;
            // Wait for 2 seconds before applying damage again
            yield return new WaitForSeconds(2f);
        }

        // Remove color filter
        renderer.material.color = originalColor;

        StopCoroutine(damageOverTimeCoroutine);
    }

    public IEnumerator Freeze()
    {
        // Change color filter to blue
        Renderer renderer = GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        renderer.material.color = Color.blue;

        // Freeze object for 3 seconds.
        isFrozen = true;
        yield return new WaitForSeconds(3f);
        isFrozen = false;


        // Remove color filter
        renderer.material.color = originalColor;

        StopCoroutine(freezeCoroutine);
    }
}
