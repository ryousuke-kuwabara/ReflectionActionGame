using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverImage : MonoBehaviour
{
    public void TransitionToResult()
    {
        SceneManager.LoadScene("Result");
    }
}
