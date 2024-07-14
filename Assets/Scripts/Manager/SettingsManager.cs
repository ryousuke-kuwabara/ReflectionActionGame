using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public float bgmVolume { get; private set; } = 0.5f;
    public float sfxVolume { get; private set; } = 0.5f;

    private void Awake()
    {
        // 60fps
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        SoundManager.Instance.ChangeBgmVolume(bgmVolume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("Title");
    }
}
