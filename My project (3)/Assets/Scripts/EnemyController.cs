using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int enemyType;
    private int health;
    private GameObject self;
    private GameObject tower;
    private Rigidbody selfRB;
    private float moveSpeed;
    bool atTower;
    float towerDistance;

    void Start()
    {
        self = gameObject;
        selfRB = self.GetComponent<Rigidbody>();
        tower = GameObject.Find("Tower");
        atTower = false;

        switch (self.name) {
            case string s when s.StartsWith("NormalEnemy"):
                enemyType = 1;
                break;
            case string s when s.StartsWith("FlyingEnemy"):
                enemyType = 2;
                break;
            case string s when s.StartsWith("HeavyEnemy"):
                enemyType = 3;
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
            case 1:
                moveSpeed = 4f;
                health = 1;
                break;
            case 2:
                moveSpeed = 6f;
                health = 3;
                break;
            case 3:
                moveSpeed = 3f;
                health = 10;
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
        } else
        {
            atTower = false;
        }
        if (atTower == false)
        {
            selfRB.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
