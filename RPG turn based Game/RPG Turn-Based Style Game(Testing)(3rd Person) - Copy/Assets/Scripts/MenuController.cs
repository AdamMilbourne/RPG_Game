using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    //Settings Menu Variables -----------------------------------------

    //Volume Settings Varibles -----------------------------------------
    [SerializeField] private TMP_Text VolumeTextValue = null;
    [SerializeField] private Slider VolumeSlider = null;

    [SerializeField] private GameObject confirmationPrompt = null;
    [SerializeField] private float defaultVolume = 50f;

    //Gameplay Settings Variables --------------------------------------
    [SerializeField] private TMP_Text SensitivityTextValue = null;
    [SerializeField] private Slider SensitivitySlider = null;
    [SerializeField] private int defaultSens = 50;
    public int mainControllerSen = 4;
    [SerializeField] private Toggle invertYToggle = null;

    //Graphics Settings Variables --------------------------------------
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private TMP_Text brightnessTextValue;
    [SerializeField] private float defaultBrightness = 50;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullscreenToggle; 

    private int _qualityLevel;
    private bool _isFullScreen;
    private float _brightnessLevel;
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;


    //Main Menu Variables -----------------------------------------
    public string newGame;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialouge = null;


    //start function (load)
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resOptions = new list<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resOptions.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        qualityDropdown.value = 1;
        QualitySettings.SetQualityLevel(1);
    }


    //Main Menu Functions
    public void NewGameDialougeYes()
    {
        SceneManager.LoadScene(newGame);
    }

    public void loadGameDialougeYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialouge.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    //Settings Menu Functions
    

    //Volume Functions
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        VolumeTextValue.text = volume.ToString("0");

    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        StartCoroutine(ConfirmBox());
    }


    // Gameplay Functions
    
    public void SetSensitivity(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        SensitivityTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        if(invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }

        PlayerPrefs.SetFloat("mastersens", mainControllerSen);
        StartCoroutine(ConfirmBox());
    }


    //Grpahics Functions

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0");

    }

    public void SetFullscreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);

        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        PlayerPrefs.SetInt("masterFullscreen", (_isFullScreen ? 1 : 0));
        Screen.fullScreen = _isFullScreen;

        StartCoroutine(ConfirmBox());
    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
  

    //Multi Functions

    public void ResetToDefault(string MenuType)
    {
       if(MenuType == "Audio Settings")
        {
            AudioListener.volume = defaultVolume;
            VolumeSlider.value = defaultVolume;
            VolumeTextValue.text = defaultVolume.ToString("0");
            VolumeApply();
        }

       if(MenuType == "Gameplay Settings")
        {
            SensitivityTextValue.text = defaultSens.ToString("0");
            SensitivitySlider.value = defaultSens;
            mainControllerSen = defaultSens;
            invertYToggle.isOn = false;
            GameplayApply();
        }
       
       if(MenuType == "Graphics Settings")
        {
            brightnessSlider.value = defaultBrightness;
            brightnessTextValue.text = defaultBrightness.ToString("0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullscreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
    }

    public IEnumerator ConfirmBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
