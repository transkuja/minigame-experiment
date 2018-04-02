using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UWPAndXInput;

public class PlayerController : MonoBehaviour {

    public PossibleInputs currentInput;
    GamePadState curState;
    GamePadState prevState;
    public bool areInputsUnlocked = true;

    public int currentCombo = 0;
    public GameObject comboUI;

    public int CurrentCombo
    {
        get
        {
            return currentCombo;
        }

        set
        {
            currentCombo = value;

            // update combo
            comboUI.GetComponent<Text>().text = "X " + currentCombo;
        }
    }

    private void Start()
    {
        CurrentCombo = 0;
    }

    private void Update()
    {
        prevState = curState;
        curState = GamePad.GetState(0);

        if (areInputsUnlocked)
            CompareInput();
    }

    void CompareInput()
    {
        switch(currentInput)
        {
            case PossibleInputs.A:
                if (prevState.Buttons.A == ButtonState.Released && curState.Buttons.A == ButtonState.Pressed)
                    GameManager.instance.GoodInput();
                else
                    if (
                        (prevState.Buttons.Y == ButtonState.Released && curState.Buttons.Y == ButtonState.Pressed) ||
                        (prevState.Buttons.X == ButtonState.Released && curState.Buttons.X == ButtonState.Pressed) ||
                        (prevState.Buttons.B == ButtonState.Released && curState.Buttons.B == ButtonState.Pressed) ||
                        (prevState.Triggers.Left < 0.3f && curState.Triggers.Left > 0.3f) ||
                        (prevState.Triggers.Right < 0.3f && curState.Triggers.Right > 0.3f)
                    )
                        CurrentCombo = 0;
                break;
            case PossibleInputs.X:
                if (prevState.Buttons.X == ButtonState.Released && curState.Buttons.X == ButtonState.Pressed)
                    GameManager.instance.GoodInput();
                else
                    if (
                        (prevState.Buttons.Y == ButtonState.Released && curState.Buttons.Y == ButtonState.Pressed) ||
                        (prevState.Buttons.A == ButtonState.Released && curState.Buttons.A == ButtonState.Pressed) ||
                        (prevState.Buttons.B == ButtonState.Released && curState.Buttons.B == ButtonState.Pressed) ||
                        (prevState.Triggers.Left < 0.3f && curState.Triggers.Left > 0.3f) ||
                        (prevState.Triggers.Right < 0.3f && curState.Triggers.Right > 0.3f)
                    )
                        CurrentCombo = 0;
                break;
            case PossibleInputs.Y:
                if (prevState.Buttons.Y == ButtonState.Released && curState.Buttons.Y == ButtonState.Pressed)
                    GameManager.instance.GoodInput();
                else
                    if (
                        (prevState.Buttons.A == ButtonState.Released && curState.Buttons.A == ButtonState.Pressed) ||
                        (prevState.Buttons.X == ButtonState.Released && curState.Buttons.X == ButtonState.Pressed) ||
                        (prevState.Buttons.B == ButtonState.Released && curState.Buttons.B == ButtonState.Pressed) ||
                        (prevState.Triggers.Left < 0.3f && curState.Triggers.Left > 0.3f) ||
                        (prevState.Triggers.Right < 0.3f && curState.Triggers.Right > 0.3f)
                    )
                        CurrentCombo = 0;
                break;
            case PossibleInputs.LT:
                if (prevState.Triggers.Left < 0.1f && curState.Triggers.Left > 0.1f)
                    GameManager.instance.GoodInput();
                else
                    if (
                        (prevState.Buttons.Y == ButtonState.Released && curState.Buttons.Y == ButtonState.Pressed) ||
                        (prevState.Buttons.X == ButtonState.Released && curState.Buttons.X == ButtonState.Pressed) ||
                        (prevState.Buttons.B == ButtonState.Released && curState.Buttons.B == ButtonState.Pressed) ||
                        (prevState.Buttons.A == ButtonState.Released && curState.Buttons.A == ButtonState.Pressed) ||
                        (prevState.Triggers.Right < 0.3f && curState.Triggers.Right > 0.3f)
                    )
                        CurrentCombo = 0;
                break;
            case PossibleInputs.RT:
                if (prevState.Triggers.Right < 0.1f && curState.Triggers.Right > 0.1f)
                    GameManager.instance.GoodInput();
                else
                    if (
                        (prevState.Buttons.Y == ButtonState.Released && curState.Buttons.Y == ButtonState.Pressed) ||
                        (prevState.Buttons.X == ButtonState.Released && curState.Buttons.X == ButtonState.Pressed) ||
                        (prevState.Buttons.B == ButtonState.Released && curState.Buttons.B == ButtonState.Pressed) ||
                        (prevState.Triggers.Left < 0.3f && curState.Triggers.Left > 0.3f) ||
                        (prevState.Buttons.A == ButtonState.Released && curState.Buttons.A == ButtonState.Pressed)
                    )
                    CurrentCombo = 0;
                break;
            default:
                break;
        }
    }

    public void UpdateCurrentInput(PossibleInputs _newInput)
    {
        currentInput = _newInput;
    }

}