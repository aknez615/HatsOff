using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static PlayerInputActions;

namespace teamFourFinalProject
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Platformer/InputReader")]

    public class InputReader : ScriptableObject, IPlayerActions
    {
        public event UnityAction<Vector2> Move = delegate { };
        public event UnityAction<Vector2, bool> Look = delegate { };
        public event UnityAction EnableMouseControlCamera = delegate { };
        public event UnityAction DisableMouseControlCamera = delegate { };
        public event UnityAction<bool> Jump = delegate { };
        public event UnityAction ActivatePowerup = delegate { };
        public event UnityAction Pause = delegate { };

        PlayerInputActions inputActions;

        public Vector3 Direction => (Vector3)inputActions.Player.Move.ReadValue<Vector2>();

        void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerInputActions();
                inputActions.Player.SetCallbacks(instance: this);
            }
        }

        public void EnablePlayerActions()
        {
            inputActions.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Move.Invoke(arg0: context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            Look.Invoke(context.ReadValue<Vector2>(), IsDeviceMouse(context));
        }

        bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";

        public void OnMouseControlCamera(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    EnableMouseControlCamera.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    DisableMouseControlCamera.Invoke();
                    break;
            }
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Jump.Invoke(arg0: true);
                    break;
                case InputActionPhase.Canceled:
                    Jump.Invoke(arg0: false);
                    break;
            }
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                Pause.Invoke();
            }
        }

        public void OnPowerup(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                ActivatePowerup.Invoke();
            }
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            //noop
        }
    }
}