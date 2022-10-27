using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterWarning : MonoBehaviour
{

    public InformationManager im;
    private AudioSource warningAS;
    bool audioFinished = true;
    bool isUnderwater = false;
    bool prevState = false;

    // Start is called before the first frame update
    void Start()
    {
        warningAS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float currDepth = im.GetDepth();
        Debug.Log("The current depth is " + currDepth.ToString());
        if (currDepth < 0f)
        {
            prevState = isUnderwater;
            isUnderwater = true;
        } else
        {
            prevState = isUnderwater;
            isUnderwater = false;
        }

        if (!prevState && isUnderwater && audioFinished)
        {
            Debug.Log("I am underwater. Playing audio.");
            StartCoroutine(AudioCompletion());
        }
    }

    IEnumerator AudioCompletion()
    {
        audioFinished = false;
        warningAS.Play();
        yield return new WaitForSeconds(warningAS.clip.length);
        audioFinished = true;
    }
}
