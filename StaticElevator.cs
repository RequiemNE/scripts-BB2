using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticElevator : MonoBehaviour
{
    [SerializeField] private Vector3 ofset = new Vector3(0, 0, 0);

    [Tooltip("Speed is divion and INT. Lower numbers mean faster movement")]
    [SerializeField] private int speed = 5;

    private Vector3 startPos;
    private Vector3 endPos;
    private float timer = 0;
    private bool goUp = false;
    private bool goDown = false;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
        endPos = transform.position + ofset;
    }

    // Update is called once per frame
    private void Update()
    {
        if (goUp)
        {
            transform.position = Vector3.Lerp(startPos, endPos, timer / speed);
            timer += Time.deltaTime;
        }
        else if (goDown)
        {
            transform.position = Vector3.Lerp(endPos, startPos, timer / speed);
            timer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            timer = 0;
            goUp = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            timer = 0;
            goUp = false;
            goDown = true;
        }
    }
}