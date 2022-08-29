using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTweaks : MonoBehaviour
{
    [SerializeField] private float liftAmount = 2f;

    [Tooltip("Speed is a division. The higher the number, the slower the speed.")]
    [SerializeField] private float speed = 1f;

    [Tooltip("Controls if the object floats up and down.")]
    [SerializeField] private bool canHover;

    [Tooltip("Controls if the object can rotate.")]
    [SerializeField] private bool canRotate;

    [SerializeField] private float rotateSpeed = 90f;
    private float yPos;
    private float amount;

    // Start is called before the first frame update
    private void Start()
    {
        yPos = transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canHover)
        {
            amount = Mathf.PingPong(Time.time / speed, liftAmount);
            float goBy = yPos + amount;
            Vector3 newTarget = new Vector3(transform.position.x, goBy, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newTarget, speed * Time.deltaTime);
        }

        if (canRotate)
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }
}