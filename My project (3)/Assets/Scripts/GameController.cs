using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject NormalEnemyPrefab;
    public GameObject FlyingEnemyPrefab;
    public GameObject HeavyEnemyPrefab;
    public GameObject Tower;
    public int waveNum;

    private int enemyType1Count;
    private int enemyType2Count;
    private int enemyType3Count;
    private int totalEnemyCount;
    private float normalSpawnRate = 0.6f;
    private float flyingSpawnRate = 0.05f;
    private float heavySpawnRate = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        waveNum = 1;
        totalEnemyCount = 1;
        UpdateWave();
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalEnemyCount <= 0)
        {
            waveNum++;
            UpdateWave();
        }
    }

    void UpdateWave()
    {
        enemyType1Count = Mathf.FloorToInt(waveNum * 10 * normalSpawnRate);
        enemyType2Count = Mathf.FloorToInt(waveNum * 7 * flyingSpawnRate);
        enemyType3Count = Mathf.FloorToInt(waveNum * 4 * heavySpawnRate);

        if (enemyType1Count < 1)
        {
            enemyType1Count = 0;
        }
        if (enemyType2Count < 1)
        {
            enemyType2Count = 0;
        }
        if (enemyType3Count < 1)
        {
            enemyType3Count = 0;
        }
    }

    void SpawnWave()
    {
        totalEnemyCount = 0;
        float randX;
        float randY;
        float randZ;
        for (int i = 0; i < enemyType1Count; i++)
        {
            randX = Random.Range(-50f, 50f);
            randZ = Random.Range(-100f, -300f);
            Vector3 randPos = new Vector3(randX, 5, randZ);
            Instantiate(NormalEnemyPrefab, randPos, Quaternion.identity);
            totalEnemyCount++;
        }
        for (int i = 0; i < enemyType2Count; i++)
        {
            randX = Random.Range(-50f, 50f);
            randY = Random.Range(6f, 10f);
            randZ = Random.Range(-150f, -500f);
            Vector3 randPos = new Vector3(randX, randY, randZ);
            Instantiate(FlyingEnemyPrefab, randPos, Quaternion.identity);
            totalEnemyCount++;
        }
        for (int i = 0; i < enemyType3Count; i++)
        {
            randX = Random.Range(-50f, 50f);
            randZ = Random.Range(-100f, -150f);
            Vector3 randPos = new Vector3(randX, 5, randZ);
            Instantiate(HeavyEnemyPrefab, randPos, Quaternion.identity);
            totalEnemyCount++;
        }
    }
}
