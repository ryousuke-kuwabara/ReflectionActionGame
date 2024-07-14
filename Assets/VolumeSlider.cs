using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public void SetBgmVolume(float volume)
    {
        SoundManager.Instance.ChangeBgmVolume(volume);
    }
}
