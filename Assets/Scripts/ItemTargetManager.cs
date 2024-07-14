using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTargetManager : MonoBehaviour
{
    public static ItemTargetManager Instance;

    public BabyController Baby;
    public HandController Hand;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
