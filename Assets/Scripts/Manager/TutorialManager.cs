using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialImages;

    private void Start()
    {
        int isPlayedBefore = PlayerPrefs.GetInt("isPlayed", 0);

        if (isPlayedBefore == 0)
        {
            Time.timeScale = 0f;
            Debug.Log("初回起動検知！");

            tutorialImages.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
        }

        PlayerPrefs.SetInt("isPlayed", 1);
    }
}
