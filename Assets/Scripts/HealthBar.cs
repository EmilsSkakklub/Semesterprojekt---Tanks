using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    public void updateHealth(int health)
    {
        slider.value = health;
    }
}
