using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandTeleport : MonoBehaviour
{
    OVRHand hand;
    public Text pinchDebug;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        // float ringFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
        OVRHand.TrackingConfidence confidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        if ((confidence == OVRHand.TrackingConfidence.High) && isIndexFingerPinching)
        {
            pinchDebug.text = "Pinching";
        } else
        {
            pinchDebug.text = "Not";
        }
    }
}
