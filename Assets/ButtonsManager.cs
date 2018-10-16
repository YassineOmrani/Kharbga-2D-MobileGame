using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour {

    public GameObject PausePanel;
    public GameplayScript gps;
    private bool selector;
    

    private void Awake()
    {
        selector = true;
        gps = GameObject.Find("GameManager").GetComponent<GameplayScript>();
    }

   

    public void resume()
    {
        PausePanel.SetActive(false);
        GameObject.Find("Cells").SetActive(true);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void openPausePanel()
    {
        PausePanel.SetActive(selector);
        selector = !selector;
    }

    public void replay()
    {
        SceneManager.LoadScene(0);
    }

}
