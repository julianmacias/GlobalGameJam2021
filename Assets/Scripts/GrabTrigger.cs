using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrigger : MonoBehaviour
{
    public GameObject objectInRange;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickable" && objectInRange == null)
        {
            objectInRange = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectInRange)
        {
            objectInRange = null;
        }
    }
}
