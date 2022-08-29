using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingLight : MonoBehaviour
{
    private Light myLight;
    [SerializeField] private float flashingSpeed, intensity;

    // Start is called before the first frame update
    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    private void Update()
    {
        myLight.intensity = Mathf.PingPong(Time.time * flashingSpeed, intensity);
    }
}