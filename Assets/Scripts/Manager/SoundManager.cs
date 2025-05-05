using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum EBGMType
    {
        BGM_TITLE = 0,
        BGM_STAGE1 = 1
    }

    public enum ESFXType
    {
        SFX_BTN = 0,
        SFX_UP = 1,
        SFX_DOWN = 2,
        SFX_CRASH = 3,
        SFX_SKILL = 4,
        SFX_SKILL2 = 5,
        SFX_DASH = 6,
        SFX_SPRINT = 7
    }

    public static SoundManager Instance;

    //audio clip 담을 수 있는 배열
    [SerializeField] private AudioClip[] bgms;
    [SerializeField] private AudioClip[] sfxs;

    //플레이하는 AudioSource
    [SerializeField] private AudioSource audioBgm;
    [SerializeField] private AudioSource audioSfx;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBGM(EBGMType.BGM_TITLE);
    }

    public void PlayBGM(EBGMType _bgmType, float _volume = 1.0f)
    {
        audioBgm.clip = bgms[(int)_bgmType];
        audioBgm.volume = _volume;
        audioBgm.Play();
    }

    public void StopBGM()
    {
        audioBgm.Stop();
    }

    public void PlaySFX(ESFXType _sfxType, float _volume = 1.0f, float _pitch = 1.0f)
    {
        audioSfx.pitch = _pitch;
        audioSfx.PlayOneShot(sfxs[(int)_sfxType], _volume);
    }

    public void StopSFX()
    {
        audioSfx.Stop();
    }
}
