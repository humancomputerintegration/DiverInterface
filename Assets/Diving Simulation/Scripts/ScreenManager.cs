using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    public List<GameObject> screens;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToScreen (int i)
    {
        int correctedIndex = (int)Mathf.Clamp(i-1, 0, screens.Count);
        for(int s = 0; s < screens.Count; s++)
        {
            if (s == correctedIndex)
            {
                screens[s].SetActive(true);
            } else
            {
                screens[s].SetActive(false);
            }
        }
    }
}
