using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGeneration : MonoBehaviour
{
    [SerializeField] private GameObject tunnel;

    private const float SPAWN_AMOUNT = 2975f;

    // Start is called before the first frame update
    private void Start()
    {
        // current tunnel pos + 2975 = new tunnel pos.
        // match scale and rotation.
    }

    // Update is called once per frame
    private void Update()
    {
    }
}