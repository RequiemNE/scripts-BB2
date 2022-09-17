using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 playerShrinkAmount;
    private bool shrinkPlayer = false;

    // Update is called once per frame
    private void Update()
    {
        if (shrinkPlayer & player.transform.localScale.x > 0.01)
        {
            player.transform.localScale -= playerShrinkAmount * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            shrinkPlayer = true;

            // move to next level.
            // if last level go to main menu
        }
    }
}