using UnityEngine;

[CreateAssetMenu(fileName = "SeData", menuName = "ScriptableObjects/Se_Create")]
public class SESoundData : ScriptableObject
{
    public SeName _name;
    public AudioClip _audioClip;
    [Range(0, 1)]
    public float _volume = 1f;
}

public enum SeName
{
    TitleToMain,
    OptionOpenClose,
    GetPickupableItem,
    GetBabyWalker,
    GetBabyCar,
    GetBabyBottle,
    GetBabyTissue,
    GetBabyRattle,
    GetBabyMike,
    BabyCrawl,
    BestScoreUpdatedResult,
    NormalResult,
    ReturnToTitle,
    Retry,
    Main,
    Result,
    Option,
    GameOver
}
