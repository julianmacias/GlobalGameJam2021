using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxGrabArea : MonoBehaviour
{
    public List<GameObject> objectsInRange = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            objectsInRange.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            if (other.gameObject.GetComponent<FixedJoint>() != null)
            {
                Destroy(other.gameObject.GetComponent<FixedJoint>());
            }
            objectsInRange.Remove(other.gameObject);
            if (other.name == "Cereal_box")
            {
                other.gameObject.GetComponent<CerealBox>().pickedUp = false;
            }
        }
    }
}
