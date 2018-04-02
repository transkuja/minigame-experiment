using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the food meter behavior
/// </summary>
public class FoodMeterHandler : MonoBehaviour {

    // Food meter settings
    public int foodMeterStep = 10;

    public float decreaseSpeed; // good feeling with 60
    public float decreaseSpeedWhenFullMultiplier; // with 60, 1.5 is quite good

    Slider slider;
    Image fillImage;

	void Start () {
        slider = GetComponent<Slider>();
        slider.value = 0;
        fillImage = transform.GetChild(1).GetComponentInChildren<Image>();
    }
	
	void Update () {
        if (IsSliderValueNull())
            return;

        slider.value -= Time.deltaTime * decreaseSpeed;
    }

    bool IsSliderValueNull()
    {
        if (slider.value <= 0.0f)
        {
            slider.value = 0;
            fillImage.enabled = false;
            if (!GameManager.instance.playerControllerRef.areInputsUnlocked)
            {
                decreaseSpeed /= decreaseSpeedWhenFullMultiplier;
                GameManager.instance.playerControllerRef.areInputsUnlocked = true;
            }
            return true;
        }
        if (!fillImage.enabled) fillImage.enabled = true;
        return false;
    }

    public void FoodMeterIncrease()
    {
        slider.value += foodMeterStep;
        if (slider.value >= slider.maxValue)
        {
            decreaseSpeed *= decreaseSpeedWhenFullMultiplier;
            GameManager.instance.playerControllerRef.areInputsUnlocked = false;
        }
    }
}
