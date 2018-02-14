using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;




public class PlayerController : MonoBehaviour {

    [Header("Speed")]
    [Tooltip("in m/s")] [SerializeField] float xSpeed;
    [Tooltip("in m/s")] [SerializeField] float ySpeed;

    [Header("Screen position based")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 1.5f;

    [Header("Screen control based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlYawFactor = 20f;
    [SerializeField] float controlRollFactor = -20f;
	

    float xThrow, yThrow;
    bool isControlEnabled = true;


   // Update is called once per frame
    void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void OnPlayerDeath()
    {
        isControlEnabled = false;
        print("freeze controls");
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawchDueToControlThrow = xThrow * controlYawFactor;

        float yaw = yawDueToPosition + yawchDueToControlThrow;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    private void ProcessTranslation()
    {
        float ClampedX = HorizontalAxisControls();
        float ClampedY = VerticalAxisControl();



        transform.localPosition = new Vector3(ClampedX, ClampedY, transform.localPosition.z);
    }


    private float VerticalAxisControl()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;

        float ClampedY = Mathf.Clamp(rawNewYPos, -3, 4);
        return ClampedY;


    }

    private float HorizontalAxisControls()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;

        float ClampedX = Mathf.Clamp(rawNewXPos, -6, 7);
        return ClampedX;
    }
}
