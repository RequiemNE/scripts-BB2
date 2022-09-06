using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 yAdd = new Vector3(0, 10, 0);
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            // ADD SOUNDS
            playerMovement.StopMomentum();
            StartCoroutine("ResetPosition");
        }
        if (collision.collider.tag == "checkpoint")
        {
            startPos = transform.position;
        }
        if (collision.collider.tag == "endlevel")
        {
            // load next level.
            Debug.Log("Level end");
        }
    }

    private IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(1f);

        transform.position = startPos + yAdd;
    }
}