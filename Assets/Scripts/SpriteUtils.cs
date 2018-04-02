using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteUtils : MonoBehaviour {

    public Sprite AButtonSprite;
    public Sprite XButtonSprite;
    public Sprite YButtonSprite;
    public Sprite LTButtonSprite;
    public Sprite RTButtonSprite;

    public Sprite GetSpriteFromInput(PossibleInputs _input)
    {
        switch(_input)
        {
            case PossibleInputs.A:
                return AButtonSprite;
            case PossibleInputs.X:
                return XButtonSprite;
            case PossibleInputs.Y:
                return YButtonSprite;
            case PossibleInputs.LT:
                return LTButtonSprite;
            case PossibleInputs.RT:
                return RTButtonSprite;
            default:
                return null;
        }
    }
}
