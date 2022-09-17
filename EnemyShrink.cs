using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShrink : MonoBehaviour
{
    [SerializeField] private Vector3 shrinkAmount;
    [SerializeField] private float holdTime = 1f;
    private bool shrink = true;
    private bool expand = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (shrink && transform.localScale.x > 0.01f)
        {
            StartCoroutine("Shrink");
            shrink = false;
        }
        if (expand && transform.localScale.x < 0.01f)
        {
            StartCoroutine("Expand");
            expand = false;
        }
    }

    private IEnumerator Shrink()
    {
        yield return new WaitForSeconds(holdTime);

        if (transform.localScale.x > 0.01f)
        {
            transform.localScale -= shrinkAmount * Time.deltaTime;
        }
        expand = true;
    }

    private IEnumerator Expand()
    {
        yield return new WaitForSeconds(holdTime);
        if (transform.localScale.x >= 0.01f)
        {
            transform.localScale += shrinkAmount * Time.deltaTime;
        }
        shrink = true;
    }
}