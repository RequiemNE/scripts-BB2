using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject sceneInfo;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 playerShrinkAmount;
    [SerializeField] private Image image;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float soundFadeSpeed = 5f;
    private AudioSource aud;
    private float reduce;
    private bool shrinkPlayer = false;
    private bool endLevel = false;

    private void Start()
    {
        aud = sceneInfo.GetComponent<AudioSource>();
        image.enabled = true;
        image.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        reduce = aud.volume;
    }

    // Update is called once per frame
    private void Update()
    {
        if (shrinkPlayer && player.transform.localScale.x > 0.01)
        {
            player.transform.localScale -= playerShrinkAmount * Time.deltaTime;
        }

        if (endLevel)
        {
            image.CrossFadeAlpha(1f, fadeSpeed, false);

            aud.volume = Mathf.Lerp(reduce, 0f, Time.time / soundFadeSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            shrinkPlayer = true;
            endLevel = true;

            // move to next level.
            // if last level go to main menu
        }
    }
}