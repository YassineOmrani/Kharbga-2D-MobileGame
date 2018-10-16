using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uimanager : MonoBehaviour {

    public Slider slider;
    public GameObject settingsPanel;
    public AudioSource volumeAudio;
    private bool selector;


    private void Awake()
    {
        selector = true;
    }

    public void goToGamePlayScene()
    {
        SceneManager.LoadScene(0);
    }

    public void appearSettingsPanel()
    {
        settingsPanel.SetActive(selector);
        selector = !selector;
    }
    public void VolumeController()
    {
        volumeAudio.volume = slider.value  ;
    }
}
