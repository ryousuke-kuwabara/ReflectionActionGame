using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _optionPanel;
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Button _titleButton;
    [SerializeField] private Button _closeButton;

    private void Start()
    {
        _bgmSlider.value = SettingsManager.Instance.bgmVolume;
        _sfxSlider.value = SettingsManager.Instance.sfxVolume;

        _bgmSlider.onValueChanged.AddListener(SettingsManager.Instance.SetBGMVolume);
        _sfxSlider.onValueChanged.AddListener(SettingsManager.Instance.SetSFXVolume);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _optionPanel.SetActive(true);
        SoundManager.Instance.PlaySe(SeName.OptionOpenClose);
    }
}
