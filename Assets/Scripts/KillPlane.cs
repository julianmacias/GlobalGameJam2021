using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject blackSheep;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Key")
        {
            other.gameObject.transform.position = respawnPoint.position;
        }
        else
        {
            if(other.name == "hips")
            {
                Destroy(other.transform.parent.gameObject);
            }
            else if(other.name == "blackSheep")
            {
                Destroy(other.transform.parent.gameObject);
                Instantiate(blackSheep, respawnPoint.position, Quaternion.Euler(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)));
            }
            else
            Destroy(other.gameObject);
        }
    }
}
