using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddedScoreText : MonoBehaviour
{
    private Transform _transform;
    private TextMeshProUGUI _text;

    void Start()
    {
        _transform = this.GetComponent<Transform>();
        _text = this.GetComponent<TextMeshProUGUI>();

        var removeSequence = DOTween.Sequence();

        removeSequence
            .Join(_transform.DOMoveX(0.5f, 1.5f).SetDelay(0.5f))
            .Join(_text.DOFade(0f, 0.5f));

        removeSequence.Play()
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
}
