using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject flowStartPos, flowEndPos;
    [SerializeField] private int flowSpeed;
    [SerializeField] private float flowTimerCheck = 5f;
    public bool enableCamera = true;
    private Vector3 offset;

    // For Lerp Cam
    private bool lerpCamera = false;

    private bool resetCamera = false;
    private Vector3 beforeLerpPosition, toLerpTo;

    private Quaternion beforeLerpRotation, toRotateTo;
    private float flowTimer = 0f;
    private float lerpTimer = 0f;

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
            transform.position = Vector3.Lerp(beforeLerpPosition, toLerpTo, lerpTimer / flowSpeed);
            transform.rotation = Quaternion.Lerp(beforeLerpRotation, toRotateTo, lerpTimer / flowSpeed);
            lerpTimer += Time.deltaTime;
        }
        if (resetCamera)
        {
            beforeLerpPosition = transform.position;
            transform.position = Vector3.Lerp(toLerpTo, beforeLerpPosition, lerpTimer / flowSpeed);
            transform.rotation = Quaternion.Lerp(toRotateTo, beforeLerpRotation, lerpTimer / flowSpeed);
            lerpTimer += Time.deltaTime;
            if (lerpTimer >= flowTimerCheck)
            {
                resetCamera = false;
            }
        }
    }

    private void FlowCamera()
    {
        PlayerMovement playerMov = player.GetComponent<PlayerMovement>();
        if (flowTimer < flowTimerCheck && flowStartPos)
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

    public void LerpCamera(Vector3 lerpPos, Quaternion lerpRotation, int newFlowSpeed)
    {
        beforeLerpPosition = gameObject.transform.position;
        beforeLerpRotation = gameObject.transform.rotation;
        flowSpeed = newFlowSpeed;
        toLerpTo = lerpPos;
        toRotateTo = lerpRotation;
        lerpTimer = 0f;
        lerpCamera = true;
    }

    public void ResetCamera()
    {
        // change FlowTimerCheck here, as it needs to stay at 5 at start for intro Lerp.
        // Changing it here though helps with lerping the cam back to position.
        flowTimerCheck = 3;
        lerpCamera = false;
        lerpTimer = 0f;
        resetCamera = true;
    }
}