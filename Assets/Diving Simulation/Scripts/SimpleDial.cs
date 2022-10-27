using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleDial : MonoBehaviour
{

    public CallTowerManager ctm;
    private AudioSource aS;
    private bool isBusy = false;
    private bool isIncomingCall = false;

    public AudioClip ringtone;
    private AudioClip incomingCall;
    private int incomingCallerFrequency = 0;

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void QuickDial(int freq)
    {
        if (!isBusy) // You need to hangup to make a call.
        {
            isBusy = true;
            aS.clip = ctm.CallCrewmate(freq);
            aS.Play();
        }
    }

    public bool IncomingCall(AudioClip speaker, int freq)
    {
        if (!isBusy && !isIncomingCall)
        {
            incomingCall = speaker;
            incomingCallerFrequency = freq;
            isIncomingCall = true;
            isBusy = true;

            aS.clip = ringtone;
            aS.loop = true;
            aS.Play();
        }

        return !isBusy;

    }

    public void AnswerCall()
    {
        if (isIncomingCall)
        {
            aS.Stop();
            aS.loop = false;
            aS.clip = incomingCall;
            aS.Play();
            isIncomingCall = false;
        }
    }

    public void HangUp()
    {
        if (isBusy)
        {
            aS.Stop();
            isBusy = false;
            isIncomingCall = false;
        }
    }
}
