using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keyhole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key")
        {
            SceneManager.LoadScene("Test", LoadSceneMode.Single);
        }
    }
}
