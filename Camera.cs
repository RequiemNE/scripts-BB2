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
    private float flowTimer = 0f;

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
}