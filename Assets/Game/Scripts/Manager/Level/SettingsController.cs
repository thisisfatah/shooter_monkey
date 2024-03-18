using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Image bgmImg;
    [SerializeField] Image sfxImg;
    [Space(10)]
    [SerializeField] Sprite BgmMuteSprite;
    [SerializeField] Sprite SfxMuteSprite;

    Sprite BgmDefaultSprite;
    Sprite SfxDefaultSprite;
    bool isMutedBgm;
    bool isMutedSfx;

    private void Start()
    {
        if(bgmImg != null && sfxImg != null)
        {
            BgmDefaultSprite = bgmImg.sprite;
            SfxDefaultSprite = sfxImg.sprite;
        }
    }

    public void MutedBgm()
    {
        if (!isMutedBgm)
        {
            isMutedBgm = true;
            bgmImg.sprite = BgmMuteSprite;
            AudioManager.MuteBgm(true);
        }
        else
        {
            isMutedBgm = false;
            bgmImg.sprite = BgmDefaultSprite;
            AudioManager.MuteBgm(false);
        }
    }

    public void MutedSfx()
    {
        if (!isMutedSfx)
        {
            isMutedSfx = true;
            sfxImg.sprite = SfxMuteSprite;
            AudioManager.MuteSfx(true);
        }
        else
        {
            isMutedSfx = false;
            sfxImg.sprite = SfxDefaultSprite;
            AudioManager.MuteSfx(false);
        }
    }
}
