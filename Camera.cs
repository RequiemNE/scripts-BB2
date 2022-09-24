using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject flowStartPos, flowEndPos;
    [SerializeField] private GameObject lerpPoint;
    [SerializeField] private int flowSpeed;
    [SerializeField] private float flowTimerCheck = 5f;
    public bool enableCamera = true;
    private bool lerpCamera = false;
    private Vector3 offset;

    // For Lerp Cam
    private Vector3 beforeLerpPosition, toLerpTo;

    private Quaternion beforeLerpRotation, toRotateTo;
    private float flowTimer = 0f;
    private float lerpTimer = 0f;
    private float xRotateAmount = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.transform.position;
        PlayerMovement playerMov = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (enableCamera)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            FlowCamera();
        }
        if (lerpCamera)
        {
            //enableCamera = false;
            transform.position = Vector3.Lerp(beforeLerpPosition, toLerpTo, lerpTimer / flowSpeed);
            transform.rotation = Quaternion.Lerp(beforeLerpRotation, toRotateTo, lerpTimer / flowSpeed);
            lerpTimer += Time.deltaTime;
        }
    }

    private void FlowCamera()
    {
        PlayerMovement playerMov = player.GetComponent<PlayerMovement>();
        if (flowTimer < flowTimerCheck)
        {
            playerMov.canMove = false;
            enableCamera = false;
            transform.position = Vector3.Slerp(flowStartPos.transform.position, flowEndPos.transform.position, flowTimer / flowSpeed);
            flowTimer += Time.deltaTime;
        }
        else
        {
            enableCamera = true;
            playerMov.canMove = true;
        }
    }

    public void LerpCamera(Vector3 lerpPos, Quaternion lerpRotation)
    {
        // lerp and qlerp to point.
        // use trigger
        beforeLerpPosition = gameObject.transform.position;
        beforeLerpRotation = gameObject.transform.rotation;
        toLerpTo = lerpPos;
        toRotateTo = lerpRotation;
        lerpTimer = 0f;
        lerpCamera = true;
    }
}