using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // getting audio manager in other script
    public static AudioManager Instance;

    // array sound value
    [SerializeField] Sound[] sounds;

    private void Awake()
    {
        // checking instance, if null instance is this
        if (Instance == null) Instance = this;
        else Destroy(this);

        // dont destroy on loading level
        DontDestroyOnLoad(this);

        // to spawn component
        foreach (Sound s in Instance.sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.loop = s.loop;
            s.source.clip = s.sound;
            s.source.volume = s.volume;
        }
    }

    public static void PlaySound(string soundName)
    {
        // check instance, if null return
        if (Instance == null) return;
        // check sounds array, if null return
        if (Instance.sounds.Length == 0) return;

        // finding sound by string
        Sound sound = Array.Find(Instance.sounds, s => s.name == soundName);

        // if sound is null return / not play
        if (sound == null && sound.sound == null) return;

        // play sound
        sound.source.Play();
    }

    public static void StopSound(string soundName, float Duration)
    {
        // check instance, if null return
        if (Instance == null) return;
        // check sounds array, if null return
        if (Instance.sounds.Length == 0) return;

        // finding sound by string
        Sound sound = Array.Find(Instance.sounds, s => s.name == soundName);

        // if sound is null return / not play
        if (sound == null) return;

        // fading sound
        sound.source.DOFade(0, Duration).OnComplete(() =>
        {
            // if complete stopping sound
            sound.source.Stop();
            // back sound volume to normal
            sound.source.volume = sound.volume;
        });
    }

    public static void MuteSound(string name, bool isMute)
    {
        // check instance, if null return
        if (Instance == null) return;
        // check sounds array, if null return
        if (Instance.sounds.Length == 0) return;

        // finding sound by string
        Sound sound = Array.Find(Instance.sounds, s => s.name == name);

        // if sound is null return / not play
        if (sound == null) return;

        sound.source.volume = isMute ? sound.volume : 0;
    }

    public static void MuteAllSound(bool isMute)
    {
        // check instance, if null return
        if (Instance == null) return;
        // check sounds array, if null return
        if (Instance.sounds.Length == 0) return;

        // to spawn component
        foreach (Sound s in Instance.sounds)
        {
            if (s == null) continue;

            s.source.volume = isMute ? 0 : s.volume;
        }
    }

    public static void MuteBgm(bool isMute)
    {
        // check instance, if null return
        if (Instance == null) return;
        // check sounds array, if null return
        if (Instance.sounds.Length == 0) return;

        // to spawn component
        foreach (Sound s in Instance.sounds)
        {
            if (s == null) continue;

            if (s.type != SoundType.BgmType) continue;

            s.source.volume = isMute ? 0 : s.volume;
        }
    }

    public static void MuteSfx(bool isMute)
    {
        // check instance, if null return
        if (Instance == null) return;
        // check sounds array, if null return
        if (Instance.sounds.Length == 0) return;

        // to spawn component
        foreach (Sound s in Instance.sounds)
        {
            if (s == null) continue;

            if (s.type != SoundType.SfxType) continue;

            s.source.volume = isMute ? 0 : s.volume;
        }
    }

    public static AudioSource GetAudioSource(string soundName)
    {
        // check instance, if null return
        if (Instance == null) return null;

        // finding sound by string
        Sound sound = Array.Find(Instance.sounds, s => s.name == soundName);

        // returning audio source get by string
        return sound == null ? null : sound.source;
    }

    public static AudioClip GetClipAudio(string soundName)
    {
        if (Instance == null) return null;

        Sound sound = Array.Find(Instance.sounds, s => s.name == soundName);

        return sound.sound;
    }
}
