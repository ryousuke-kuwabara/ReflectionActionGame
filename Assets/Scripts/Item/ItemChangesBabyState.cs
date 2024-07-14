using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChangesBabyState : Item
{
    [SerializeField] private BabyState babyStateToChange;
    private BabyController babyController;
}
