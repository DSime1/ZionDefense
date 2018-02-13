using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class Player : MonoBehaviour {

    [Tooltip("in m/s")] [SerializeField] float xSpeed = 10f;
    //[Tooltip("in m")] [SerializeField] float xRange = 7f;
    [Tooltip("in m/s")] [SerializeField] float ySpeed = 10f;
    //[Tooltip("in m")] [SerializeField] float yRange = 4f;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float ClampedX;
        float ClampedY;

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;

        ClampedX = Mathf.Clamp(rawNewXPos, -6, 7);
        ClampedY = Mathf.Clamp(rawNewYPos, -3, 4);



        transform.localPosition = new Vector3(ClampedX, ClampedY, transform.localPosition.z);

       

        print("X  "+ rawNewXPos +" "+ transform.localPosition);
        print("Y "+ rawNewYPos + " " + transform.localPosition);

	}
}
