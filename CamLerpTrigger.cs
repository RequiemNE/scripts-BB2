using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLerpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject lerpPoint;
    [SerializeField] private GameObject myCam;

    [Tooltip("Flow Speed is division. Lower number means faster speed.")]
    [SerializeField] private int newFlowSpeed = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Camera camScript = myCam.GetComponent<Camera>();
            camScript.LerpCamera(lerpPoint.transform.position, lerpPoint.transform.rotation, newFlowSpeed);
            // lerpPoint.transform.rotation
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Make trigger collider a bit longer than area so player doesn't
        // keep going in and out.

        if (other.gameObject.name == "Player")
        {
            Camera camScript = myCam.GetComponent<Camera>();
            camScript.ResetCamera();
        }
    }
}