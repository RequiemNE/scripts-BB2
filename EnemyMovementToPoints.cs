using System.Collections;
using UnityEngine;

public class EnemyMovementToPoints : MonoBehaviour
{
    // arrays for points to move to
    // Coroutines for pauses.

    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float waitTime = 1.0f;
    private bool canMove = true;

    // lerp from currentPos, to movePont[x]
    // if i =  movepoint[max], then i = 0.

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoints[1].transform.position, speed * Time.deltaTime);
        //for (int i = 0; i <= movePoints.Length; i++)
        //{
        //    float step = speed * Time.deltaTime;
        //    Debug.Log("Moving to movePoint " + i);
        //    transform.position = Vector3.MoveTowards(transform.position, movePoints[i].transform.position, step);
        //    if (i >= movePoints.Length)
        //    {
        //        Debug.Log("Resetting i to 0");
        //        i = 0;
        //    }
        //    canMove = true;
        //}
    }

    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {
            //StartCoroutine("Move");
            canMove = false;
        }

        //transform.position = Vector3.MoveTowards(transform.position, movePoints[1].transform.position, speed * Time.deltaTime);

        for (int i = 0; i <= movePoints.Length; i++)
        {
            float step = speed * Time.deltaTime;
            Debug.Log("Moving to movePoint " + i);
            transform.position = Vector3.MoveTowards(transform.position, movePoints[i].transform.position, step);
            //if (i >= movePoints.Length)
            //{
            //    Debug.Log("Resetting i to 0");
            //    i = 0;
            //}
        }
    }

    private IEnumerator Move()
    {
        float step = speed * Time.deltaTime;
        for (int i = 0; i <= movePoints.Length; i++)
        {
            if (i > movePoints.Length)
            {
                Debug.Log("Resetting i to 0");
                i = 0;
            }
            Debug.Log("Moving to movePoint " + i);
            Debug.Log(movePoints[i]);
            transform.position = Vector3.MoveTowards(transform.position, movePoints[i].transform.position, step);
            yield return new WaitForSeconds(waitTime);

            canMove = true;
            yield return null;
        }
    }
}