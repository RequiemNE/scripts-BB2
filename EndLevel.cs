using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject sceneInfo;
    [SerializeField] private AudioClip levelEndJingle;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 playerShrinkAmount;
    [SerializeField] private Image image;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float soundFadeSpeed = 5f;
    private AudioSource aud;
    private float reduce;
    private bool shrinkPlayer = false;
    private bool endLevel = false;
    private bool hasHitEnd = false;

    private void Start()
    {
        aud = sceneInfo.GetComponent<AudioSource>();
        image.enabled = true;
        image.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        reduce = aud.volume;
    }

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
        if (collision.collider.tag == "player" && !hasHitEnd)
        {
            shrinkPlayer = true;
            endLevel = true;
            // Using second audio source from player below, as I lerp the volume of sceneInfo audio.
            // This prevents both bits of audio from becoming quiter.
            AudioSource levelAud = GetComponent<AudioSource>();
            levelAud.PlayOneShot(levelEndJingle);

            StartCoroutine("LoadNextLevel");

            hasHitEnd = true;
        }
    }

    private void SaveProgress()
    {
        SaveGame saveGame = gameObject.GetComponent<SaveGame>();
        string sceneName = SceneManager.GetActiveScene().name;
        int sceneInt = 0;
        switch (sceneName)
        {
            case "level-1":
                sceneInt = 1;
                break;

            case "level-2":
                sceneInt = 2;
                break;

            case "level-3":
                sceneInt = 3;
                break;

            case "level-4":
                sceneInt = 4;
                break;

            case "level-5":
                sceneInt = 5;
                break;

            default:
                Debug.Log("Level option out of scope. Level name: " + sceneName +
                    " is not level-1 to level-5.");
                break;
        }
        if (sceneInt >= 1 && sceneInt <= 5)
        {
            saveGame.Save(sceneInt);
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(3f);

        int sceneCount = SceneManager.sceneCountInBuildSettings - 1;
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene != sceneCount)
        {
            int nextScene = currentScene + 1;
            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
        }
        if (currentScene == sceneCount)
        {
            Debug.Log("You win");
            // load main menu?
        }
        // should alse have, if "classic" level 3, next scene should say, "you unlocked Minimal mode."
    }
}