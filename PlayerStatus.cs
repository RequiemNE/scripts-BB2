using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 yAdd = new Vector3(0, 10, 0);
    private PlayerMovement playerMovement;
    private AudioSource aud;
    public GameObject cam;
    [SerializeField] private AudioClip fallScream, resetSound, killedByEnemy;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
        playerMovement = GetComponent<PlayerMovement>();
        aud = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            aud.PlayOneShot(killedByEnemy);
            Camera camScript = cam.GetComponent<Camera>();
            camScript.enableCamera = false;
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
            // WORKS
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "kill box")
        {
            aud.PlayOneShot(fallScream);
            Camera camScript = cam.GetComponent<Camera>();
            camScript.enableCamera = false;
            playerMovement.StopMomentum();
            StartCoroutine("ResetPosition");
        }
    }

    private IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(1f);

        Camera camScript = cam.GetComponent<Camera>();
        camScript.enableCamera = true;
        aud.PlayOneShot(resetSound);
        transform.position = startPos + yAdd;
    }
}