using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLerpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject lerpPoint;
    [SerializeField] private GameObject myCam;
    [SerializeField] private float xRotateAmount;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Camera camScript = myCam.GetComponent<Camera>();
            camScript.LerpCamera(lerpPoint.transform.position, lerpPoint.transform.rotation);
            // lerpPoint.transform.rotation
        }
    }
}