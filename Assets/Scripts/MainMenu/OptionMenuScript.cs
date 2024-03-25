using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuScript : MonoBehaviour
{
    public GameObject keySettingObj;
    public GameObject settingTipObj;
    public GameObject soundTipObj;
    
    [Header("Panel")]
    public GameObject keySettingPanel;
    public GameObject soundSettingPanel;
    
    [Header("Button")]
    public Button keySettingButton;
    public Button soundSettingButton;
    
    [Header("Tip Image")]
    public Sprite[] tipImageKeyBoard;
    public Sprite[] tipImageGamePad;
    
    [Header("Sound Slider")]
    public Slider musicSlider;
    public Slider audioSlider;
    
    [Header("Image Objects")]
    private Image keySettingImage;
    private Image settingTipImage;
    private Image soundTipImage;
    
    private void Start()
    {
        keySettingImage = keySettingObj.GetComponent<Image>();
        settingTipImage = settingTipObj.GetComponent<Image>();
        soundTipImage = soundTipObj.GetComponent<Image>();
        
        if (InputDeviceUpdate.i.inputType == InputDeviceUpdate.InputType.Keyboard)
        {
            SetTipKeyBoard(0);
        }
        else if (InputDeviceUpdate.i.inputType == InputDeviceUpdate.InputType.Gamepad)
        {
            SetTipGamePad(0);
        }
    }

    private void OnEnable()
    {
        keySettingButton.Select();
    }

    private void Update()
    {
        if (InputDeviceUpdate.i.inputType == InputDeviceUpdate.InputType.Keyboard)
        {
            SetTipKeyBoard(0);
        }
        else if (InputDeviceUpdate.i.inputType == InputDeviceUpdate.InputType.Gamepad)
        {
            SetTipGamePad(0);
        }
        
        if(InputDeviceUpdate.i.playerInput.actions["Back"].triggered)
        {
            Back();
        }
    }

    public void SetTipKeyBoard(int index)
    {
        settingTipImage.sprite = tipImageKeyBoard[index];
        soundTipImage.sprite = tipImageKeyBoard[index+1];
        
        keySettingImage.sprite = tipImageKeyBoard[index+2];
        
        settingTipImage.SetNativeSize();
        soundTipImage.SetNativeSize();
    }
    
    public void SetTipGamePad(int index)
    {
        settingTipImage.sprite = tipImageGamePad[index];
        soundTipImage.sprite = tipImageGamePad[index+1];
        
        keySettingImage.sprite = tipImageGamePad[index+2];
        
        settingTipImage.SetNativeSize();
        soundTipImage.SetNativeSize();
    }
    
    public void KeySetting()
    {
        keySettingPanel.SetActive(true);
        soundSettingPanel.SetActive(false);

        foreach (var selectable in this.GetComponentsInChildren<Selectable>())
        {
            selectable.interactable = false;
        }
    }
    
    public void SoundSetting()
    {
        keySettingPanel.SetActive(false);
        soundSettingPanel.SetActive(true);
        /*foreach (var selectable in this.GetComponentsInChildren<Selectable>())
        {
            selectable.interactable = false;
        }*/
        musicSlider.interactable = true;
        audioSlider.interactable = true;
        musicSlider.Select();
    }
    
    public void Back()
    {
        keySettingPanel.SetActive(false);
        soundSettingPanel.SetActive(false);
        
        foreach (var selectable in this.GetComponentsInChildren<Selectable>())
        {
            selectable.interactable = true;
        }
        keySettingButton.Select();
    }
    
    public void SetMusicVolume(float volume)
    {
        //MusicManager.i.SetVolume(volume);
        Debug.Log(volume);
    }
    
    public void SetAudioVolume(float volume)
    {
        //SoundManager.i.SetVolume(volume);
        Debug.Log(volume);
    }
}