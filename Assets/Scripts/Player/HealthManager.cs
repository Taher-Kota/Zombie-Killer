using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private float Health;
    private Slider slider;
    

    private void Awake()
    {
        slider = GetComponent<Slider>();
        Health = slider.value;
    }

    public void DealDamage(float damage)
    {
        slider.value -= damage;
        if (slider.value < 0) 
        { 
            slider.value = 0;
            Health = slider.value;
        }
        if (slider.value == 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
