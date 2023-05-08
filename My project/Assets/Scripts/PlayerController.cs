using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -15f;


    private float horizontalInput;
    private float verticalInput;
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessTranslation()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // keeps yRange locked to a 16:9 aspect ratio
        float yRange = xRange * 9f / 16f;

        float xOffset = horizontalInput * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = verticalInput * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlInput = verticalInput * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlInput;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalInput * positionYawFactor * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("FIRE!");
        }
        else
        {
            Debug.Log("NO FIRE");
        }
    }
}
