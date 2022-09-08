using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public bool enableCamera = true;
    private Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (enableCamera)
        {
            transform.position = player.transform.position + offset;
        }
    }
}