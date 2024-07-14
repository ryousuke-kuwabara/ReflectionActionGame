using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    private void OnDisable()
    {
        Time.timeScale = 1.0f;
        SoundManager.Instance.UnPauseLoopSe();
    }

    private void OnEnable()
    {
        Time.timeScale = 0.0f;
        SoundManager.Instance.PauseLoopSe();
    }

    public void ReturnToTitleScreen()
    {
        SoundManager.Instance.PlaySe(SeName.ReturnToTitle);
        SceneManager.LoadScene("Title");

        SoundManager.Instance.StopLoopSe();
    }

    public void CloseOption()
    {
        this.gameObject.SetActive(false);
        SoundManager.Instance.PlaySe(SeName.OptionOpenClose);
    }
}
