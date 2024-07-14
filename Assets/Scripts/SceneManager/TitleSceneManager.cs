using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _openingObject;
    [SerializeField] private VideoPlayer _openingVideo;
    [SerializeField] private float _openingStartSeconds;
    [SerializeField] private Camera _camera;

    public void TransitionToMainScene()
    {
        SceneManager.LoadScene("Main");
        SoundManager.Instance.PlaySe(SeName.TitleToMain);

        SoundManager.Instance.StopLoopSe();
    }

    private void Start()
    {
        _openingVideo.loopPointReached += OnMovieFinished;

        _openingVideo.targetTexture.Release();
        SoundManager.Instance.PlayBgm(BgmName.Title);

        StartCoroutine(PlayOpeningMovie());
    }

    private IEnumerator PlayOpeningMovie()
    {
        yield return new WaitForSeconds(_openingStartSeconds);

        _camera.backgroundColor = Color.black;
        _openingObject.SetActive(true);
        _openingVideo.Play();
    }

    public void OnMovieFinished(VideoPlayer player)
    {
        _camera.backgroundColor = Color.white;
        _openingObject.SetActive(false);
        _openingVideo.Stop();

        StartCoroutine(PlayOpeningMovie());
    }
}
