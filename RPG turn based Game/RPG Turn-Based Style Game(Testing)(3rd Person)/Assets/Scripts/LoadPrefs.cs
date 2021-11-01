using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    //General Settings
    [SerializeField] private bool canUse = false;
    [SerializeField] private MenuController menuController;

    //Audio Settings
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    //Graphics settings
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private TMP_Text brightnessTextValue;
    
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [SerializeField] private Toggle fullscreenToggle;

    [SerializeField] private TMP_Text SensitivityTextValue = null;
    [SerializeField] private Slider SensitivitySlider = null;

    [SerializeField] private Toggle invertYToggle = null;

    private void awake()
    {
        if(canUse)
        {
            if(PlayerPrefs.HasKey("MasterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("MasterVolume");

                volumeTextValue.text = localVolume.ToString("0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.ResetToDefault("Audio Settings");
            }

            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }

            if (PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");

                if((localFullscreen == 1))
                {
                    Screen.fullScreen = true;
                    fullscreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullscreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessTextValue.text = localBrightness.ToString("0");
                brightnessSlider.value = localBrightness;
                //change brightness here
            }

            if (PlayerPrefs.HasKey(""))
            {
                float localSens = PlayerPrefs.GetFloat("mastersens");

                SensitivityTextValue.text = localSens.ToString("0");
                SensitivitySlider.value = localSens;
                menuController.mainControllerSen = Mathf.RoundToInt(localSens);
            }

            if (PlayerPrefs.HasKey("masterInvertY"))
            {
                if (PlayerPrefs.GetInt("masterInvertY") == 1)
                {
                    invertYToggle.isOn = true;
                }
                else
                {
                    invertYToggle.isOn = false;
                }
            }
        }
    }
}

