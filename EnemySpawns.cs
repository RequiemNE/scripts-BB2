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

    // Update is called once per frame
    private void Update()
    {
        if (spawnEnemy)
        {
            TimerChoice();
        }
    }

    private void TimerChoice()
    {
        spawnEnemy = false;
        Debug.Log("in TimerChoice");
        float randomChoice = Random.Range(0, 3);
        Debug.Log("Timer rand :" + randomChoice);

        switch (randomChoice)
        {
            case 0:
                StartCoroutine(SpawnEnemy(COUNTDOWN1));
                break;

            case 1:
                StartCoroutine(SpawnEnemy(COUNTDOWN2));
                break;

            case 2:
                StartCoroutine(SpawnEnemy(COUNTDOWN3));
                break;
        }
    }

    private IEnumerator SpawnEnemy(float countdown)
    {
        Debug.Log("in countdown");
        //UnityEngine.Debug.Log(timer);
        yield return new WaitForSeconds(countdown);

        int randomSpawn = Random.Range(0, 2);
        Debug.Log("spawn rand :" + randomSpawn);
        GameObject rndSpawn = spawnPoints[randomSpawn];
        Instantiate(enemy, rndSpawn.transform.position, rndSpawn.transform.rotation);
        spawnEnemy = true;

        yield return null;
    }
}