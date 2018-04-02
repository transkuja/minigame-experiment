using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PossibleInputs { A, X, Y, LT, RT, Size }
public class InputsMeterHandler : MonoBehaviour {
    enum InputsUIChildren { Slider, CurrentInput, NextInput }
    PossibleInputs nextInput;

    Slider slider;
    Image currentInputImg;
    Image nextInputImg;

    // Input meter settings
    public int nextInputCounter = 10; // Rand(3, 10)
    public int minCounter = 5;
    public int maxCounter = 15;

    void Start () {
        nextInputCounter = Random.Range(minCounter, maxCounter);
        slider = GetComponentInChildren<Slider>();
        slider.value = 0;
        slider.maxValue = nextInputCounter;
        currentInputImg = transform.GetChild((int)InputsUIChildren.CurrentInput).GetComponent<Image>();
        nextInputImg = transform.GetChild((int)InputsUIChildren.NextInput).GetComponent<Image>();
        nextInputImg.sprite = GetRandomInput();
    }

    public void InputMeterIncrease()
    {
        slider.value++;
        if (slider.value == nextInputCounter)
        {
            slider.value = 0;
            nextInputCounter = Random.Range(minCounter, maxCounter);
            slider.maxValue = nextInputCounter;
            currentInputImg.sprite = nextInputImg.sprite;
            GameManager.instance.playerControllerRef.UpdateCurrentInput(nextInput);
            nextInputImg.sprite = GetRandomInput();
        }
    }

    Sprite GetRandomInput()
    {
        nextInput = (PossibleInputs)Random.Range(0, (int)PossibleInputs.Size);

        return GetComponent<SpriteUtils>().GetSpriteFromInput(nextInput);
    }
}
