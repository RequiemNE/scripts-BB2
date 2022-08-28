using System.Collections;
using UnityEngine;

public class EnemyMovementToPoints : MonoBehaviour
{
    // add in slight rotation for enemy - swaying side to side.
    // possibly need to use quaternion look rotation.

    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float waitTime = 1.0f;
    private bool canMove = true;
    private int movePointItem;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        MoveObj(movePointItem);

        if (canMove)
        {
            StartCoroutine("Move");
            canMove = false;
        }
    }

    private IEnumerator Move()
    {
        for (int i = 0; i < movePoints.Length; i++)
        {
            movePointItem = i;
            yield return new WaitForSeconds(waitTime);
        }
        canMove = true;
        yield return null;
    }

    private void MoveObj(int item)
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoints[item].transform.position, speed * Time.deltaTime);
    }
}