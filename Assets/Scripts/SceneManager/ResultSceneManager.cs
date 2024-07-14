using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    public void TransitionToMainScene()
    {
        SoundManager.Instance.PlaySe(SeName.Retry);
        SceneManager.LoadScene("Main");
    }

    public void TransitionToTitleScene()
    {
        SoundManager.Instance.PlaySe(SeName.ReturnToTitle);
        SceneManager.LoadScene("Title");
    }
}
