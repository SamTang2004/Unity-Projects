using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaTest : MonoBehaviour
{
    public Slider manaSlider;
    public float refillSpeed;
    public bool refilling;
    public KeyCode MapedKey;
    // Start is called before the first frame update
    void Start()
    {
        manaSlider = GetComponent<Slider> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (refilling)
        {
            manaSlider.value = manaSlider.value < 1 ? manaSlider.value + (refillSpeed * Time.deltaTime) : manaSlider.value;
            if (manaSlider.value >= 1)
            {
                refilling = false;
            }
        }
        if (Input.GetKeyDown(MapedKey))
        {
            refilling = false;
            manaSlider.value = manaSlider.value - 0.1f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            refilling = true;
        }
    }
}
