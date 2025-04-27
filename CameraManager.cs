using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using KBCore.Refs;
using UnityEngine;

namespace teamFourFinalProject
{

    public class CameraManager : ValidatedMonoBehaviour
    {
        [Header("References")]
        [SerializeField, Anywhere] InputReader input;
        [SerializeField, Anywhere] CinemachineFreeLook freeLookVCam;

        [Header("Settings")]
        [SerializeField, Range(0.5f, 3f)] float speedMultiplier = 1f;

        bool isRMBPressed;
        bool cameraMovementLock;

        void Start()
        {
            //yield return null;

            //FixMainCameraTag();

            Debug.Log("Main camera is: " + Camera.main.name);
        }

        void OnEnable()
        {
            input.Look += OnLook;
            input.EnableMouseControlCamera += OnEnableMouseControlCamera;
            input.DisableMouseControlCamera += OnDisableMouseControlCamera;
        }

        void OnDisable()
        {
            input.Look += OnLook;
            input.EnableMouseControlCamera += OnEnableMouseControlCamera;
            input.DisableMouseControlCamera += OnDisableMouseControlCamera;
        }

        void OnLook(Vector2 cameraMovement, bool isDeviceMouse)
        {
            if (cameraMovementLock) return;

            if (isDeviceMouse && !isRMBPressed) return;

            //If mouse use fixedDeltaTime, else use deltaTime
            float deviceMultiplyer = isDeviceMouse ? Time.fixedDeltaTime : Time.deltaTime;

            //Camera axis values
            freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * speedMultiplier * deviceMultiplyer;
            freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * speedMultiplier * deviceMultiplyer;
        }

        void OnEnableMouseControlCamera()
        {
            isRMBPressed = true;

            //Lock cursor and hide
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(routine: DisableMouseForFrame());
        }

        void OnDisableMouseControlCamera()
        {
            isRMBPressed = false;

            //Unlock cursor and make visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //Reset camera to prevent jumping
            freeLookVCam.m_XAxis.m_InputAxisValue = 0f;
            freeLookVCam.m_YAxis.m_InputAxisValue = 0f;
        }

        IEnumerator DisableMouseForFrame()
        {
            cameraMovementLock = true;
            yield return new WaitForEndOfFrame();
            cameraMovementLock = false;
        }

        void FixMainCameraTag()
        {
            Camera[] allCameras = Camera.allCameras;

            foreach (Camera cam in allCameras)
            {
                if (cam.CompareTag("MainCamera"))
                {
                    Debug.Log("Untaggin camera: " + cam.name);
                    cam.tag = "Untagged";
                }
            }

            Camera gameplayCam = GetComponent<Camera>();
            if (gameplayCam != null)
            {
                gameplayCam.tag = "MainCamera";
                Debug.Log("Assigned MainCamera tag to: " +gameplayCam.name);
            }
        }
    }
}
