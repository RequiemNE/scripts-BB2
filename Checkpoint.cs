using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Color[] colour;
    private Renderer myColour;
    private AudioSource ding;
    private bool checkpointHit = false;

    private void Start()
    {
        myColour = gameObject.GetComponent<Renderer>();
        ding = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!checkpointHit)
        {
            if (collision.collider.tag == "player")
            {
                myColour.material.SetColor("_Color", colour[1]);
                ding.Play();
                checkpointHit = true;
            }
        }
    }
}