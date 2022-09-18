using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 playerShrinkAmount;
    [SerializeField] private Image image;
    [SerializeField] private float fadeSpeed = 1f;
    private bool shrinkPlayer = false;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (shrinkPlayer & player.transform.localScale.x > 0.01)
        {
            player.transform.localScale -= playerShrinkAmount * Time.deltaTime;
            //image.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            //image.CrossFadeAlpha(1f, fadeSpeed, false);
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