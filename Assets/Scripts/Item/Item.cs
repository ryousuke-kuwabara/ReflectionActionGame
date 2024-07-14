using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] protected int _onPickupScore;
    [SerializeField] protected int _onUseScore;

    [SerializeField] private float _timeToDelete;
    private float _existingTime;

    private void Start()
    {
        var seq = DOTween.Sequence();

        seq.Append(this.transform.DOScale(new Vector3((this.transform.localScale.x * 0.85f), (this.transform.localScale.y * 0.85f), 0f), 2f));
        seq.Append(this.transform.DOScale(new Vector3(this.transform.localScale.x, this.transform.localScale.y, 0f), 2f));

        seq.SetLoops(-1, LoopType.Restart).SetLink(gameObject);
    }

    private void Update()
    {
        _existingTime += Time.deltaTime;

        if (_existingTime >= _timeToDelete)
        {
            Destroy(this.gameObject);
        }
    }

    public Sprite GetSprite()
    {
        return this.GetComponent<SpriteRenderer>().sprite;
    }
}
