using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Slider volumeSlider;

    private float currentVolume;
    private Resolution[] resolutions;

    // Start is called before the first frame update
    private void Start()
    {
        // generate a list and loop through all available resolutions until players screen resolution.
        // then add to list.
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Add all resoltuions to drop down. Load any saved settings.
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("VolumePreference"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        }
        else
        {
            volumeSlider.value = 0;
        }
        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
        }
    }
}