using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Vector3 movArea;
    public GameObject arm;
    private Vector3 handPos;
    private float x, y, z, rotX;
    public Animator aThumb, aIndex, aMiddle, aRing, aPinky;
    private int fingers1, fingers2, fingers3;
    public GrabTrigger grabArea1, grabArea2, grabArea3;
    public Rigidbody wrist;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        //Debug.Log(Input.mouseScrollDelta);


        if (Input.GetMouseButton(1))
        {
            rotX = map((Input.mousePosition.x / Screen.width), 0, 1, -180, 180);
            arm.transform.localEulerAngles = new Vector3(rotX, -90, 0);
        }
        else
        {
            x = map((Input.mousePosition.x / Screen.width), 0, 1, 0, movArea.x);
            z = map((Input.mousePosition.y / Screen.height), 0, 1, 0, movArea.z) - 0.7f;
        }

        y = y + (Input.mouseScrollDelta.y * 0.05f);
        if (y <= 0.1f) y = 0.1f;
        else if (y > movArea.y) y = movArea.y;

        handPos = new Vector3(x, y, z);

        arm.transform.position = handPos;

        if (Input.GetKeyDown("q") || Input.GetKeyDown("a"))
        {
            aPinky.SetBool("Close", true);
            fingers1 = fingers1 + 1;
            PickUp(grabArea1.objectInRange);

        }
        else if (Input.GetKeyUp("q") || Input.GetKeyUp("a"))
        {
            aPinky.SetBool("Close", false);
            fingers1 = fingers1 - 1;
            Release(grabArea1.objectInRange);

        }

        if (Input.GetKeyDown("s"))
        {
            aRing.SetBool("Close", true);
            fingers1 = fingers1 + 1;
            PickUp(grabArea1.objectInRange);

        }
        else if (Input.GetKeyUp("s"))
        {
            aRing.SetBool("Close", false);
            fingers1 = fingers1 - 1;
            Release(grabArea1.objectInRange);

        }

        if (Input.GetKeyDown("d"))
        {
            aMiddle.SetBool("Close", true);
            fingers2 = fingers2 + 1;
            PickUp(grabArea2.objectInRange);

        }
        else if (Input.GetKeyUp("d"))
        {
            aMiddle.SetBool("Close", false);
            fingers2 = fingers2 - 1;
            Release(grabArea2.objectInRange);

        }

        if (Input.GetKeyDown("f"))
        {
            aIndex.SetBool("Close", true);
            fingers2 = fingers2 + 1;
            PickUp(grabArea2.objectInRange);
        }
        else if (Input.GetKeyUp("f"))
        {
            aIndex.SetBool("Close", false);
            fingers2 = fingers2 - 1;
            Release(grabArea2.objectInRange);
        }

        if (Input.GetKeyDown("space"))
        {
            aThumb.SetBool("Close", true);
            fingers3 = fingers3 + 1;
            PickUp(grabArea3.objectInRange);
        }
        else if (Input.GetKeyUp("space"))
        {
            aThumb.SetBool("Close", false);
            fingers3 = fingers3 - 1;
            Release(grabArea3.objectInRange);
        }
    }
    public void PickUp(GameObject obj)
    {
        if (obj != null) ;
        else return;
        if (obj.GetComponents<FixedJoint>().Length < 1)
        {
            FixedJoint fj = obj.AddComponent<FixedJoint>();
            fj.connectedBody = wrist;
            fj.breakForce = 600;
            fj.breakTorque = 600;
        }
    }
    public void Release(GameObject obj)
    {
        if (obj != null)
        {
            Destroy(obj.GetComponent<FixedJoint>());
        }
    }
    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
