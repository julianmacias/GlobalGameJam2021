using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Vector3 movArea;
    public Transform arm, shoulder, wrist;
    private Vector3 targetPos;
    private float x, y, z;
    private float sideRot, frontRot;
    public Animator aThumb, aIndex, aMiddle, aRing, aPinky;
    private int fingers;
    public GrabTrigger grabArea;
    public MaxGrabArea maxGrabArea;
    public Rigidbody wristRB;
    public float smoothTime = 0.2F;
    private Vector3 armVelocity = Vector3.zero;
    private float handSpeed = 0.025f;
    private float handSpeedMod = 1f;
    private float grabStrength = 120;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            handSpeedMod = 0.3f;
        }
        else
        {
            handSpeedMod = 1;
        }

        if (Input.GetMouseButton(1))
        {
            sideRot = sideRot + (Input.GetAxis("Mouse X"));
            shoulder.localEulerAngles = new Vector3(sideRot, -90f, 0f);
            frontRot = frontRot + (Input.GetAxis("Mouse Y"));
            if(frontRot > 90f)
            {
                frontRot = 90f;
            }
            else if(frontRot < -90f)
            {
                frontRot = -90f;
            }
            wrist.localEulerAngles = new Vector3(wrist.localEulerAngles.x, wrist.localEulerAngles.y, frontRot);
        }
        else
        {
            x = x + (Input.GetAxis("Mouse X") * handSpeed * handSpeedMod);
            if (x > movArea.x)
            {
                x = movArea.x;
            }
            else if (x < (movArea.x * -1))
            {
                x = movArea.x * -1;
            }

            z = z + (Input.GetAxis("Mouse Y") * handSpeed * handSpeedMod);
            if (z > movArea.z)
            {
                z = movArea.z;
            }
            else if (z < (movArea.z * -1))
            {
                z = movArea.z * -1;
            }
        }
        y = y + (Input.mouseScrollDelta.y * handSpeed * handSpeedMod);
        if (y > movArea.y)
        {
            y = movArea.y;
        }
        else if (y < 0)
        {
            y = 0;
        }


        targetPos = new Vector3(x, y, z);
        arm.position = Vector3.SmoothDamp(arm.position, targetPos, ref armVelocity, smoothTime);

        if (Input.GetKeyDown("q") || Input.GetKeyDown("a"))
        {
            aPinky.SetBool("Close", true);
            fingers = fingers + 1;
            PickUp();

        }
        else if (Input.GetKeyUp("q") || Input.GetKeyUp("a"))
        {
            aPinky.SetBool("Close", false);
            fingers = fingers - 1;
            Release();

        }

        if (Input.GetKeyDown("s"))
        {
            aRing.SetBool("Close", true);
            fingers = fingers + 1;
            PickUp();

        }
        else if (Input.GetKeyUp("s"))
        {
            aRing.SetBool("Close", false);
            fingers = fingers - 1;
            Release();

        }

        if (Input.GetKeyDown("d"))
        {
            aMiddle.SetBool("Close", true);
            fingers = fingers + 1;
            PickUp();

        }
        else if (Input.GetKeyUp("d"))
        {
            aMiddle.SetBool("Close", false);
            fingers = fingers - 1;
            Release();

        }

        if (Input.GetKeyDown("f"))
        {
            aIndex.SetBool("Close", true);
            fingers = fingers + 1;
            PickUp();
        }
        else if (Input.GetKeyUp("f"))
        {
            aIndex.SetBool("Close", false);
            fingers = fingers - 1;
            Release();
        }

        if (Input.GetKeyDown("space"))
        {
            aThumb.SetBool("Close", true);
            fingers = fingers + 1;
            PickUp();
        }
        else if (Input.GetKeyUp("space"))
        {
            aThumb.SetBool("Close", false);
            fingers = fingers - 1;
            Release();
        }
    }
    public void PickUp()
    {
        if (grabArea.objectInRange != null) ;
        else return;
        if (grabArea.objectInRange.GetComponents<FixedJoint>().Length < 1)
        {
            FixedJoint fj = grabArea.objectInRange.AddComponent<FixedJoint>();
            fj.connectedBody = wristRB;
            fj.breakForce = 400;
            fj.breakTorque = 400;
        }
        else
        {
            grabArea.objectInRange.GetComponent<FixedJoint>().breakForce = grabArea.objectInRange.GetComponent<FixedJoint>().breakForce + grabStrength;
            grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque = grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque + grabStrength;
        }
    }
    public void Release()
    {
        if (fingers <= 0)
        {
            foreach (GameObject obj in maxGrabArea.objectsInRange)
            {
                Destroy(obj.GetComponent<FixedJoint>());
            }
            fingers = 0;
        }
        else if (grabArea.objectInRange != null)
        {
             if (grabArea.objectInRange.GetComponent<FixedJoint>() != null)
            {
                grabArea.objectInRange.GetComponent<FixedJoint>().breakForce = grabArea.objectInRange.GetComponent<FixedJoint>().breakForce - grabStrength;
                grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque = grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque - grabStrength;
            }
        }
    }
    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
