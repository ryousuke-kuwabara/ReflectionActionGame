using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioSource _seAudioSource;
    [SerializeField] private AudioSource _loopSeAudioSource;

    [SerializeField] private List<BGMSoundData> _bgmSoundData = new List<BGMSoundData>();
    [SerializeField] private List<SESoundData> _seSoundData = new List<SESoundData>();

    public float _bgmVolume { get; private set; } = 1f;
    public float _seVolume { get; private set; } = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayBgm(BgmName name)
    {
        BGMSoundData data = _bgmSoundData.Find(data => data._name == name);

        _bgmAudioSource.volume = data._volume * SettingsManager.Instance.bgmVolume;
        _bgmAudioSource.clip = data._audioClip;

        _bgmAudioSource.Play();
    }

    public void PlaySe(SeName name)
    {
        SESoundData data = _seSoundData.Find(data => data._name == name);

        _seAudioSource.volume = data._volume * SettingsManager.Instance.sfxVolume;
        _seAudioSource.PlayOneShot(data._audioClip);
    }

    public void PlayLoopSe(SeName name)
    {
        SESoundData data = _seSoundData.Find(data => data._name == name);

        _loopSeAudioSource.volume = data._volume * SettingsManager.Instance.sfxVolume;
        _loopSeAudioSource.clip = data._audioClip;
        
        _loopSeAudioSource.Play();
    }

    public void StopLoopSe()
    {
        _loopSeAudioSource.Stop();
    }

    public void PauseLoopSe()
    {
        _loopSeAudioSource.Pause();
    }

    public void UnPauseLoopSe()
    {
        _loopSeAudioSource.UnPause();
    }

    public void ChangeBgmVolume(float volume)
    {
        _bgmAudioSource.volume = volume;
    }
}
