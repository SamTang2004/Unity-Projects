using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCD : MonoBehaviour
{
    public Slider CDSlider;
    public bool refilling;
    public KeyCode MapedKey;
    public string textValue;
    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        textValue = " ";
        textElement.text = textValue;
        CDSlider = GetComponent<Slider> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (refilling)
        {
            CDSlider.value = CDSlider.value > 0 ? CDSlider.value - Time.deltaTime : CDSlider.value;
            textValue = CDSlider.value.ToString();
            textElement.text = textValue;
            if (CDSlider.value <= 0)
            {
                refilling = false;
                textValue = " ";
                textElement.text = textValue;
            }
        }
        if (!refilling && Input.GetKeyDown(MapedKey))
        {
            CDSlider.value = CDSlider.maxValue;
        }
        if (CDSlider.value == CDSlider.maxValue)
        {
            refilling = true;
        }
    }
}
