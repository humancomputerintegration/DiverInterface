using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour
{

    public bool trackOculusLeftHand = true;
    public Transform OculusLeftHand;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trackOculusLeftHand)
        {
            transform.position = OculusLeftHand.position;
            transform.rotation = OculusLeftHand.rotation;
        }
    }
}
