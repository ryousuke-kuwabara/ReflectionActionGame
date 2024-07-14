using UnityEngine;

[CreateAssetMenu(fileName = "BgmData", menuName = "ScriptableObjects/Bgm_Create")]
public class BGMSoundData : ScriptableObject
{
    public BgmName _name;
    public AudioClip _audioClip;
    [Range(0, 1)]
    public float _volume = 1f;
}

public enum BgmName
{
    Title,
    Main,
}
