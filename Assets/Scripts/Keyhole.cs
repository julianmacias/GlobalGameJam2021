using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keyhole : MonoBehaviour
{
    public string nextLevel;
    public Animator transition;
    public float delay = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key")
        {
            if(transition != null)
            {
                transition.SetTrigger("Play");
            }
            gameObject.GetComponent<AudioSource>().Play();
            
            StartCoroutine(OpenSceneWithDelay());
        }
    }
    IEnumerator OpenSceneWithDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }
}
