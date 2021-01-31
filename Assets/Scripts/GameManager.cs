using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool pauseState = false;
    public HandController hand;
    public MenuController menu;
    public float delay = 1;
    public bool delayFinished = true;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (!delayFinished) StartCoroutine(Delay());
    }
    private void Update()
    {
        if (Input.GetKeyDown("p") && delayFinished)
        {
            if (pauseState == false) PauseGame();
            else ResumeGame();
        }
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        hand.enabled = false;
        pauseState = true;
        menu.OpenMenu();
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        hand.enabled = true;
        pauseState = false;
        menu.CloseMenu();
        Time.timeScale = 1;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        delayFinished = true;
    }
}
