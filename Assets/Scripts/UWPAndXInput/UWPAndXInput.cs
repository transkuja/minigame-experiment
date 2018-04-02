﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if WINDOWS_UWP
using Windows.Gaming.Input;
#endif

namespace UWPAndXInput
{
    
    public static class GamePadVibration
    {
        public struct VibrationValues
        {
            public float leftMotor;
            public float rightMotor;
        }

        public static VibrationValues[] Vibrations = new VibrationValues[4];

        static CoroutinePlayer coroutinePlayer;
        public static CoroutinePlayer CoroutinePlayer
        {
            get
            {
                if (coroutinePlayer == null)
                    coroutinePlayer = new GameObject("CoroutinePlayer", typeof(CoroutinePlayer)).GetComponent<CoroutinePlayer>();
                return coroutinePlayer;
            }
        }
    }
    public class GamePad
    {
        public GamePad()
        {

        }

        public static GamePadState GetState(PlayerIndex playerIndex)
        {
            GamePadState state = new GamePadState();

#if WINDOWS_UWP
            try {
                state = FillGamePadStateStruct(Gamepad.Gamepads[(int)playerIndex].GetCurrentReading());
            }
            catch {
                state.IsConnected = false;
            }
#else
            state = FillGamePadStateStruct(XInputDotNetPure.GamePad.GetState((XInputDotNetPure.PlayerIndex)playerIndex));
            
#endif
            return state;
        }
#if WINDOWS_UWP
        static GamePadState FillGamePadStateStruct(GamepadReading _state)
        {
            //To Complete

            GamePadState state = new GamePadState();

            state.Buttons.A = ButtonState.Released;
            state.Buttons.B = ButtonState.Released;
            state.Buttons.X = ButtonState.Released;
            state.Buttons.Y = ButtonState.Released;

            state.DPad.Down = ButtonState.Released;
            state.DPad.Right = ButtonState.Released;
            state.DPad.Up = ButtonState.Released;

            state.Buttons.LeftShoulder = ButtonState.Released;
            state.Buttons.LeftStick = ButtonState.Released;
            state.Buttons.RightShoulder = ButtonState.Released;
            state.Buttons.RightStick  = ButtonState.Released;
            state.Buttons.Back  = ButtonState.Released;
            state.Buttons.Start = ButtonState.Released;

            state.Triggers.Left = (float)_state.LeftTrigger;
            state.Triggers.Right = (float)_state.RightTrigger;

            if((float)_state.LeftThumbstickX > 0.19f || (float)_state.LeftThumbstickX < -0.19f)
                state.ThumbSticks.Left.X = (float)_state.LeftThumbstickX;
            else
                state.ThumbSticks.Left.X = 0.0f;

             if((float)_state.LeftThumbstickY > 0.19f || (float)_state.LeftThumbstickY < -0.19f)
                state.ThumbSticks.Left.Y = (float)_state.LeftThumbstickY;
            else
                state.ThumbSticks.Left.Y = 0.0f;
            if((float)_state.RightThumbstickX > 0.19f || (float)_state.RightThumbstickX < -0.19f)
                state.ThumbSticks.Right.X = (float)_state.RightThumbstickX;
            else
                state.ThumbSticks.Right.X = 0.0f;

            if((float)_state.RightThumbstickY > 0.19f || (float)_state.RightThumbstickY < -0.19f)
                state.ThumbSticks.Right.Y = (float)_state.RightThumbstickY;
            else 
                state.ThumbSticks.Right.Y = 0.0f;
			
            switch(_state.Buttons)
            {
                case GamepadButtons.A:
                    state.Buttons.A = ButtonState.Pressed;
                    break;
                case GamepadButtons.B:
                    state.Buttons.B = ButtonState.Pressed;
                    break;
                case GamepadButtons.X:
                    state.Buttons.X = ButtonState.Pressed;
                    break;
                case GamepadButtons.Y:
                    state.Buttons.Y = ButtonState.Pressed;
                    break;
                case GamepadButtons.DPadDown :
                    state.DPad.Down = ButtonState.Pressed;
                    break;
                case GamepadButtons.DPadLeft :
                    state.DPad.Left = ButtonState.Pressed;
                    break;
                case GamepadButtons.DPadRight :
                    state.DPad.Right = ButtonState.Pressed;
                    break;
                case GamepadButtons.DPadUp :
                    state.DPad.Up = ButtonState.Pressed;
                    break;
                case GamepadButtons.LeftShoulder :
                    state.Buttons.LeftShoulder = ButtonState.Pressed;
                    break;
                case GamepadButtons.LeftThumbstick :
                    state.Buttons.LeftStick = ButtonState.Pressed;
                    break;
                case GamepadButtons.RightShoulder :
                    state.Buttons.RightShoulder = ButtonState.Pressed;
                    break;
                case GamepadButtons.RightThumbstick :
                    state.Buttons.RightStick  = ButtonState.Pressed;
                    break;
                case GamepadButtons.View :
                      state.Buttons.Back  = ButtonState.Pressed;
                    break;
                case GamepadButtons.Menu :
                    state.Buttons.Start = ButtonState.Pressed;
                    break;
                case GamepadButtons.Paddle1 :
                    break;
                case GamepadButtons.Paddle2 :
                    break;
                case GamepadButtons.Paddle3 :
                    break;
                case GamepadButtons.Paddle4 :
                    break;

                //GamepadButtons.None?
                //state.Buttons.Guide?
            }
        
            state.IsConnected = true;

            return state;
        }
#else
        static GamePadState FillGamePadStateStruct(XInputDotNetPure.GamePadState _state)
        {
            GamePadState state;
            state.Buttons.A = (ButtonState)_state.Buttons.A;
            state.Buttons.B = (ButtonState)_state.Buttons.B;
            state.Buttons.X = (ButtonState)_state.Buttons.X;
            state.Buttons.Y = (ButtonState)_state.Buttons.Y;

            state.Buttons.Back = (ButtonState)_state.Buttons.Back;
            state.Buttons.Start = (ButtonState)_state.Buttons.Start;
            state.Buttons.Guide = (ButtonState)_state.Buttons.Guide;

            state.Buttons.LeftShoulder = (ButtonState)_state.Buttons.LeftShoulder;
            state.Buttons.RightShoulder = (ButtonState)_state.Buttons.RightShoulder;


            state.Buttons.LeftStick = (ButtonState)_state.Buttons.LeftStick;
            state.Buttons.RightStick = (ButtonState)_state.Buttons.RightStick;

            state.DPad.Down = (ButtonState)_state.DPad.Down;
            state.DPad.Up = (ButtonState)_state.DPad.Up;
            state.DPad.Left = (ButtonState)_state.DPad.Left;
            state.DPad.Right = (ButtonState)_state.DPad.Right;

            state.Triggers.Left = _state.Triggers.Left;
            state.Triggers.Right = _state.Triggers.Right;

            if ((float)_state.ThumbSticks.Left.X > 0.19f || (float)_state.ThumbSticks.Left.X < -0.19f)
                state.ThumbSticks.Left.X = _state.ThumbSticks.Left.X;
            else
                state.ThumbSticks.Left.X = 0.0f;
            if ((float)_state.ThumbSticks.Left.Y > 0.19f || (float)_state.ThumbSticks.Left.Y < -0.19f)
                state.ThumbSticks.Left.Y = _state.ThumbSticks.Left.Y;
           else
                state.ThumbSticks.Left.Y = 0.0f;
            state.ThumbSticks.Right.X = _state.ThumbSticks.Right.X;
            state.ThumbSticks.Right.Y = _state.ThumbSticks.Right.Y;

            state.IsConnected = _state.IsConnected;
            state.PacketNumber = _state.PacketNumber;
            return state;
        }
#endif

        public static GamePadState GetState(PlayerIndex playerIndex, GamePadDeadZone deadZone)
        {
            Debug.LogWarning("WARNING: GetState(Playerindex, GamePadDeadZone) not yet supported for UWP");
            GamePadState empty = new GamePadState();
            empty.IsConnected = false;
#if WINDOWS_UWP
            return empty;
#else
            return FillGamePadStateStruct(XInputDotNetPure.GamePad.GetState((XInputDotNetPure.PlayerIndex)playerIndex, (XInputDotNetPure.GamePadDeadZone)deadZone));
#endif
        }

        public static void SetVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            if ((int)playerIndex < 0 || (int)playerIndex > 3)
                return;

            if (leftMotor < 0f)
                leftMotor = 0f;

            if (rightMotor < 0f)
                rightMotor = 0f;
#if WINDOWS_UWP
            GamepadVibration vibration = new GamepadVibration();
            vibration.LeftMotor = leftMotor;
            vibration.RightMotor = rightMotor;
            Gamepad.Gamepads[(int)playerIndex].Vibration = vibration;
#else
            XInputDotNetPure.GamePad.SetVibration((XInputDotNetPure.PlayerIndex)playerIndex, leftMotor, rightMotor);
#endif
            GamePadVibration.Vibrations[(int)playerIndex].leftMotor = leftMotor;
            GamePadVibration.Vibrations[(int)playerIndex].rightMotor = rightMotor;
        }

        public static void AddVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            SetVibration(playerIndex,
                         GamePadVibration.Vibrations[(int)playerIndex].leftMotor + leftMotor,
                         GamePadVibration.Vibrations[(int)playerIndex].rightMotor + rightMotor);
        }

        public static void SubVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            SetVibration(playerIndex,
                         GamePadVibration.Vibrations[(int)playerIndex].leftMotor - leftMotor,
                         GamePadVibration.Vibrations[(int)playerIndex].rightMotor - rightMotor);
        }

        public static void VibrateForSeconds(PlayerIndex playerIndex, float leftMotor, float rightMotor, float seconds)
        {
            GamePadVibration.CoroutinePlayer.StartCoroutine(vibrateForSeconds(playerIndex, leftMotor, rightMotor, seconds));
        }

        static IEnumerator vibrateForSeconds(PlayerIndex playerIndex, float leftMotor, float rightMotor, float seconds)
        {
            if ((int)playerIndex < 0 || (int)playerIndex > 3)
                yield break;
            AddVibration(playerIndex, leftMotor, rightMotor);
            yield return new WaitForSeconds(seconds);
            SubVibration(playerIndex, leftMotor, rightMotor);
        }
    }

    public struct GamePadState
    {
        public uint PacketNumber;
        public bool IsConnected;
        public GamePadButtons Buttons;
        public GamePadDPad DPad;
        public GamePadTriggers Triggers;
        public GamePadThumbSticks ThumbSticks;
    }

    public struct GamePadButtons
    {
        public ButtonState Start;
        public ButtonState Back;
        public ButtonState LeftStick;
        public ButtonState RightStick;
        public ButtonState LeftShoulder;
        public ButtonState RightShoulder;
        public ButtonState Guide;
        public ButtonState A;
        public ButtonState B;
        public ButtonState X;
        public ButtonState Y;
    }

    public struct GamePadDPad
    {
        public ButtonState Up;
        public ButtonState Down;
        public ButtonState Left;
        public ButtonState Right;
    }

    public struct GamePadTriggers
    {
        public float Left;
        public float Right;
    }

    public struct GamePadThumbSticks
    {
        public StickValue Left;
        public StickValue Right;

        public struct StickValue
        {
            public float X;
            public float Y;
        }
    }

    public enum ButtonState
    {
        Pressed = 0,
        Released = 1
    }

    public enum PlayerIndex
    {
        One = 0,
        Two = 1,
        Three = 2,
        Four = 3
    }

    public enum GamePadDeadZone
    {
        Circular = 0,
        IndependentAxes = 1,
        None = 2
    }
}
