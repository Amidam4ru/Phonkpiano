using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class VolumeSwitch : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerGroup _audioGroup;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(bool isOn)
    {
        if (isOn)
        {
            _audioMixer.SetFloat(_audioGroup.name, 0);
        }
        else
        {
            _audioMixer.SetFloat(_audioGroup.name, -80);
        }
    }
}
