using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioStorage))]
public class LoopSwitch : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _prevButton;
    [SerializeField] private TimeSetter _timeSetter;

    private AudioSource _audioSource;
    private AudioStorage _storage;
    private float _currentTime;
    private int _loopIndex;

    public event Action<float> Switched;

    private void Awake()
    {
        _storage = GetComponent<AudioStorage>();
        _audioSource = GetComponent<AudioSource>();
        _loopIndex = 0;
    }

    private void OnEnable()
    {
        _nextButton.onClick.AddListener(SwitchToNextLoop);
        _prevButton.onClick.AddListener(SwitchToPreviosLoop);
    }

    private void OnDisable()
    {
        _nextButton.onClick?.RemoveListener(SwitchToNextLoop);
        _prevButton.onClick?.RemoveListener(SwitchToPreviosLoop);
    }

    private void SwitchToNextLoop()
    {
        ChangeIndex(1);
    }

    private void SwitchToPreviosLoop()
    {
        ChangeIndex(-1);
    }

    private void ChangeIndex(int number)
    {
        _currentTime = _audioSource.time;

        _loopIndex += number;

        if (_loopIndex >= _storage.AudioClipsCount)
        {
            _loopIndex = 0;
        }
        else if (_loopIndex < 0)
        {
            _loopIndex = _storage.AudioClipsCount - 1;
        }

        _audioSource.time = _currentTime;
        _audioSource.clip = _storage.GetAudioClip(_loopIndex);
        Switched?.Invoke(_currentTime);
    }
}
