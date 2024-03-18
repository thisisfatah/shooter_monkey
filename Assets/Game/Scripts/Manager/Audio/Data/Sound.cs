using UnityEngine;

[System.Serializable]
public enum SoundType { BgmType, SfxType }

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip sound;

    public float volume;

    public bool loop;

    public SoundType type;

    [HideInInspector]
    public AudioSource source;
}