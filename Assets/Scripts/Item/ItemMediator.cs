using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMediator : MonoBehaviour
{
    [SerializeField] private BabyController baby;
    [SerializeField] private HandController hand;

    public BabyController Baby()
    {
        return this.baby;
    }

    public HandController Hand()
    {
        return this.hand;
    }
}
