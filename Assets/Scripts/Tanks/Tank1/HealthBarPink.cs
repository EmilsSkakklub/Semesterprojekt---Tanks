using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPink : MonoBehaviour
{

    private Slider slider;




    private void Start()
    {
        slider = GetComponent<Slider>();
    }


    public void setMaxHealth(int health)
    {
        slider.minValue = 0;
        slider.maxValue = health;
    }

    public void updateHealth(int health)
    {
        slider.value = health;
    }
}
