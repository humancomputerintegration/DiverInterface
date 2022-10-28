using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudStorm : MonoBehaviour
{

    public GameObject mudGO;
    public Camera playerCamera;
    public InformationManager infMan;

    public bool storm = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MudSurpriseOn");
    }

    // Update is called once per frame
    void Update()
    {

        if (storm && (infMan.GetDepth() > 0f))
        {
            mudGO.SetActive(false);
        } else if (storm && (infMan.GetDepth() <= 0f))
        {
            mudGO.SetActive(true);
        }
    }

    IEnumerator MudSurpriseOn()
    {
        yield return new WaitForSeconds(Random.Range(15f, 30f));
        if (!storm && (infMan.GetDepth() <= 0f) )
        {
            Debug.Log("Mud slide.");
            playerCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("PhysicalUI")); // Hide
            mudGO.SetActive(true);
            StartCoroutine("MudSurpriseOff");
            storm = true;
        }
        else
        {
            Debug.Log("Not in water for mud.");
            StartCoroutine("MudSurpriseOn");
        }
    }

    IEnumerator MudSurpriseOff()
    {
        yield return new WaitForSeconds(20f);
        Debug.Log("Mud slide subsided.");
        playerCamera.cullingMask |= 1 << LayerMask.NameToLayer("PhysicalUI"); // Show
        mudGO.SetActive(false);
        storm = false;
    }
}
