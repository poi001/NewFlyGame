using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsUI : MonoBehaviour
{
    public Slider BGM;
    public Slider SFX;
    public AudioMixer Mixer;
    public Text BGMText;
    public Text SFXText;

    ////////////////////////////////////////////Sound/////////////////////////////////////////////
    public void ChangeBGM()
    {
        SetBGMVolume(BGM.value);
        ChangeBGMText();
    }
    public void ChangeSFX()
    {
        SetSFXVolume(SFX.value);
        ChangeSFXText();
    }

    private void ChangeBGMText()
    {
        BGMText.text = "BGM: " + ((int)(BGM.value * 100)).ToString() + "%";
    }
    private void ChangeSFXText()
    {
        SFXText.text = "SFX: " + ((int)(SFX.value * 100)).ToString() + "%";
    }

    private void SetBGMVolume(float val)
    {
        Mixer.SetFloat("BGM", Mathf.Log10(val) * 20);
    }
    private void SetSFXVolume(float val)
    {
        Mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }

    ////////////////////////////////////////////Window////////////////////////////////////////////

    public void OnClickExitBtn()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
