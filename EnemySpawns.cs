using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject enemy;

    private const float COUNTDOWN1 = 5f;
    private const float COUNTDOWN2 = 8f;
    private const float COUNTDOWN3 = 2f;

    private bool spawnEnemy = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // countdown -= time.deltaTime
        // when time = 0 spawn enemy.
        // reset countdown.
        if (spawnEnemy)
        {
            TimerChoice();
        }
    }

    private void TimerChoice()
    {
        spawnEnemy = false;
        Debug.Log("in TimerChoice");
        float randomChoice = Random.Range(0, 2);
        Debug.Log("Timer rand :" + randomChoice);

        switch (randomChoice)
        {
            case 0:
                SpawnEnemy(COUNTDOWN1);
                break;

            case 1:
                SpawnEnemy(COUNTDOWN2);
                break;

            case 2:
                SpawnEnemy(COUNTDOWN3);
                break;
        }
    }

    private void SpawnEnemy(float countdown)
    {
        Debug.Log("in countdown");
        float timer = countdown;
        Debug.Log(timer);
        while (timer > 0)
        {
            // if is only running once, not continously decreasing.
            timer -= Time.deltaTime;
            Debug.Log(timer); // about 250 0.02 deltaTime messages in 0.01 seconds.
        }
        int randomSpawn = Random.Range(0, 2);
        Debug.Log("spawn rand :" + randomSpawn);
        GameObject rndSpawn = spawnPoints[randomSpawn];
        Instantiate(enemy, rndSpawn.transform.position, rndSpawn.transform.rotation);
    }
}