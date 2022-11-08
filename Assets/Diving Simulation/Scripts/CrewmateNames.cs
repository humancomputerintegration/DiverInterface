using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrewmateNames : MonoBehaviour
{

    public CallTowerManager ctm;
    private TextMeshPro textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = this.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        CrewInfo[] crewInformation = ctm.GetCrewmatesInformation();
        string crewText = "";

        foreach(CrewInfo currCrewmate in crewInformation)
        {
            string currName = currCrewmate.name;
            string currPosition = currCrewmate.worldLocation.ToString();
            crewText = crewText + currName + " "  + currPosition + "\n";
        }

        textBox.text = crewText;
    }
}
