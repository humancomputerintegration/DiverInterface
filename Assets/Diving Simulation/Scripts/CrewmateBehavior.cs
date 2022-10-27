using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewmateBehavior : MonoBehaviour
{
    
    public AudioClip callAudioReceiver;
    public AudioClip callAudioCaller;
    private int frequency;

    public CallTowerManager ctm;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomCall());
    }

    public void SetFrequency(int f)
    {
        frequency = f;
    }

    IEnumerator RandomCall ()
    {
        yield return new WaitForSeconds(Random.Range(10f, 120f));
        if (ctm.playerTransmitter.IncomingCall(callAudioCaller, frequency)) // If call failed, restart
        {
            Debug.Log("Call attempted!");
            StartCoroutine(RandomCall());
        }
        Debug.Log("Call made!");
    }
}
