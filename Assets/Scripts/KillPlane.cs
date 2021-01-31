using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public Transform respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Key")
        {
            other.gameObject.transform.position = respawnPoint.position;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
