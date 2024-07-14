using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour
{
    [SerializeField] private Sprite nextTuotorialImage;

    private Image _image;

    private void Start()
    {
        _image = this.GetComponent<Image>();
    }

    public void OnClick()
    {
        Debug.Log("hi");
        if (_image.sprite != nextTuotorialImage)
        {
            _image.sprite = nextTuotorialImage;
        } 
        else
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
