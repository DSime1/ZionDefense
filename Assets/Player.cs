using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;




public class Player : MonoBehaviour {

    [Tooltip("in m/s")] [SerializeField] float xSpeed;
    [Tooltip("in m/s")] [SerializeField] float ySpeed;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;
	

    float xThrow, yThrow;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

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
