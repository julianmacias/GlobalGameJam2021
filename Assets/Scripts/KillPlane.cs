using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Key")
        {
            Debug.Log("The key is lost");
        }
        Destroy(other.gameObject);
    }
}
