using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Slider))]
public class OxygenBar : MonoBehaviour
{
    private Slider slider;

    public InformationManager iM;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxOxygenLevel(iM.GetMaxOxygenLevel());
    }

    public void SetMaxOxygenLevel(float maxLevel)
    {
        slider.maxValue = maxLevel;
        slider.value = maxLevel; // Start with max!
    }

    public void SetOxygenLevel(float level)
    {
        slider.value = level;
    }

    private void Update()
    {
        SetOxygenLevel(iM.GetOxygenLevel());
        if (iM.GetOxygenLevel() < 80 && iM.GetOxygenLevel() > 20)
        {
            slider
                .gameObject
                .transform
                .Find("Fill")
                .GetComponent<Image>()
                .color = new Color(1F, 0.3F, 0F);
        }
        else if (iM.GetOxygenLevel() < 20)
        {
            slider
                .gameObject
                .transform
                .Find("Fill")
                .GetComponent<Image>()
                .color = Color.red;
        }
    }
}
