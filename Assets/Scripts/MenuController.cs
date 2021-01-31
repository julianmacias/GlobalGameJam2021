using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image pIcon;
    public Text pText;
    public GameObject menu, controls, options, credits;
    public void OpenMenu()
    {
        menu.SetActive(true);
        pIcon.color = new Color32(255, 255, 255, 255);
        pText.color = new Color32(58, 115, 185, 255);
    }
    public void CloseMenu()
    {
        menu.SetActive(false);
        pIcon.color = new Color32(58, 115, 185, 255);
        pText.color = new Color32(255, 255, 255, 255);
    }
    public void OpenControls()
    {
        controls.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
    }
    public void OpenOptions()
    {
        controls.SetActive(false);
        options.SetActive(true);
        credits.SetActive(false);
    }
    public void OpenCredits()
    {
        controls.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
