using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShrink : MonoBehaviour
{
    [SerializeField] private Vector3 shrinkAmount;
    [SerializeField] private float holdTime = 1f;
    public bool canChangeSize = true;
    public bool shrink = false;
    public bool expand = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (canChangeSize)
        {
            StartCoroutine("ChangeSize");
        }

        if (shrink)
        {
            Shrink();
        }

        if (expand)
        {
            Expand();
        }
    }

    private void Shrink()
    {
        if (transform.localScale.x >= 0.01f)
        {
            transform.localScale -= shrinkAmount * Time.deltaTime;
        }
        canChangeSize = true;
    }

    private void Expand()
    {
        if (transform.localScale.x <= 0.01f)
        {
            transform.localScale += shrinkAmount * Time.deltaTime;
        }
        canChangeSize = true;
    }

    private IEnumerator ChangeSize()
    {
        yield return new WaitForSeconds(holdTime);
        Debug.Log("logic");
        if (shrink)
        {
            expand = true;
            shrink = false;
        }
        if (expand)
        {
            shrink = true;
            expand = false;
        }
        if (!shrink && !expand)
        {
            shrink = true;
        }
        canChangeSize = false;
    }
}