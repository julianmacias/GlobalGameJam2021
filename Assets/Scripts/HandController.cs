using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Vector3 movArea;
    public Transform arm, shoulder;
    private Vector3 targetPos;
    private float x, y, z, targetRot;
    public Animator aThumb, aIndex, aMiddle, aRing, aPinky;
    private int fingers;
    public GrabTrigger grabArea;
    public Rigidbody wrist;
    public float smoothTime = 0.2F;
    private Vector3 armVelocity = Vector3.zero;
    private float handSpeed = 0.025f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Debug.Log(Input.GetAxis("Mouse X"));
        if (Input.GetMouseButton(1))
        {
            targetRot = targetRot + (Input.GetAxis("Mouse X"));
            shoulder.localEulerAngles = new Vector3(targetRot, -90f, 0f);
        }
        else
        {
            x = x + (Input.GetAxis("Mouse X") * handSpeed);
            if (x > movArea.x)
            {
                x = movArea.x;
            }
            else if (x < (movArea.x * -1))
            {
                x = movArea.x * -1;
            }

            z = z + (Input.GetAxis("Mouse Y") * handSpeed);
            if (z > movArea.z)
            {
                z = movArea.z;
            }
            else if (z < (movArea.z * -1))
            {
                z = movArea.z * -1;
            }
        }
            
        y = y + (Input.mouseScrollDelta.y * handSpeed);
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
            fj.connectedBody = wrist;
            fj.breakForce = 150;
            fj.breakTorque = 150;
        }
        else
        {
            grabArea.objectInRange.GetComponent<FixedJoint>().breakForce = grabArea.objectInRange.GetComponent<FixedJoint>().breakForce + 150;
            grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque = grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque + 150;
        }
    }
    public void Release()
    {
        if (grabArea.objectInRange != null)
        {
            if(fingers == 0)
            {
                Destroy(grabArea.objectInRange.GetComponent<FixedJoint>());
            }
            else if (fingers > 0)
            {
                grabArea.objectInRange.GetComponent<FixedJoint>().breakForce = grabArea.objectInRange.GetComponent<FixedJoint>().breakForce - 150;
                grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque = grabArea.objectInRange.GetComponent<FixedJoint>().breakTorque - 150;
            }
        }
    }
    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
