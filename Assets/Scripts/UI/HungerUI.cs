using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerUI : MonoBehaviour
{
    [SerializeField] private Image hungerImage;

    private float time;

    private void Start()
    {
        hungerImage.fillAmount = 1;
    }

    public void SetStartingTime(float time)
    {
        this.time = time;
    }

    public void UpdateHungerUI(float value)
    {
        hungerImage.fillAmount = value / time;
    }
}
