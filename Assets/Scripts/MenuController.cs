using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image pIcon;
    public Text pText;
    public GameObject menu, controls, options, credits;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OpenMenu()
    {
        menu.SetActive(true);
        pIcon.color = new Color32(255, 255, 255, 255);
        pText.color = new Color32(58, 115, 185, 255);
        audioSource.Play();
    }
    public void CloseMenu()
    {
        menu.SetActive(false);
        pIcon.color = new Color32(58, 115, 185, 255);
        pText.color = new Color32(255, 255, 255, 255);
        audioSource.Play();
    }
    public void OpenControls()
    {
        controls.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
        audioSource.Play();
    }
    public void OpenOptions()
    {
        controls.SetActive(false);
        options.SetActive(true);
        credits.SetActive(false);
        audioSource.Play();
    }
    public void OpenCredits()
    {
        controls.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
        audioSource.Play();
    }
    public void QuitGame()
    {
        audioSource.Play();
        StartCoroutine(QuitDelay());
    }
    IEnumerator QuitDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
