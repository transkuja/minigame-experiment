using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    // Score settings
    public int score = 0;
    public int scoreStep = 10;

    FoodMeterHandler foodMeterHandler;
    InputsMeterHandler inputsMeterHandler;

    public GameObject scoreUI;
    public GameObject foodMeterUI;
    public GameObject inputsUI;

    public PlayerController playerControllerRef;

    private void Awake()
    {
        instance = this;    
    }

    public FoodMeterHandler FoodMeterHandler
    {
        get
        {
            if (foodMeterHandler == null)
                foodMeterHandler = foodMeterUI.GetComponent<FoodMeterHandler>();
            return foodMeterHandler;
        }

        set
        {
            foodMeterHandler = value;
        }
    }

    public InputsMeterHandler InputsMeterHandler
    {
        get
        {
            if (inputsMeterHandler == null)
                inputsMeterHandler = inputsUI.GetComponent<InputsMeterHandler>();
            return inputsMeterHandler;
        }

        set
        {
            inputsMeterHandler = value;
        }
    }

    private void Start()
    {
        // Init score
        score = 0;
        scoreUI.GetComponent<Text>().text = score.ToString();

        // Food meter init
        FoodMeterHandler = foodMeterUI.GetComponent<FoodMeterHandler>();

        // Init Inputs meter
        InputsMeterHandler = inputsUI.GetComponent<InputsMeterHandler>();

    }

    // TODO: should have the player index as a parameter to play with 4P
    public void GoodInput()
    {
        // score ++
        score += scoreStep * playerControllerRef.CurrentCombo;
        scoreUI.GetComponent<Text>().text = score.ToString();

        // food meter ++
        FoodMeterHandler.FoodMeterIncrease();

        // input gauge ++
        InputsMeterHandler.InputMeterIncrease();

        // Update Combo
        playerControllerRef.CurrentCombo++;
    }
}
