using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluePickUpTimer : MonoBehaviour
{

    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }


    public void setMaxSliderValue(float value)
    {
        slider.maxValue = value;

    }

    public void updateSliderValue(float value)
    {
        slider.value = value;
    }
}
