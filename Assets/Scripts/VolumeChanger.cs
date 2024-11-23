using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerGroup _audioGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        _audioMixer.SetFloat(_audioGroup.name, Mathf.Log10(volume) * 20);
    }
}
