using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTrackingRight : MonoBehaviour
{

    public bool trackOculusRightHand = true;
    public Transform OculusRightHand;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trackOculusRightHand)
        {
            transform.position = OculusRightHand.position;
            transform.rotation = OculusRightHand.rotation;
        }
    }
}
