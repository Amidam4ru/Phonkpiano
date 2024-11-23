using System;
using UnityEngine;

[RequireComponent(typeof(AudioStorage))]
[RequireComponent(typeof(AudioSource))]
public class ActiveCowbell : MonoBehaviour
{
    private AudioStorage _cowbellsStorage;
    private AudioSource _audioSource;
    private int _clipIndex;

    public event Action<int> ClipChanged;

    private void Awake()
    {
        _clipIndex = 0;
        _cowbellsStorage = GetComponent<AudioStorage>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.clip = _cowbellsStorage.GetAudioClip(_clipIndex);
    }

    public void ChangeClip(int number)
    {
        _clipIndex += number;

        if (_clipIndex >= _cowbellsStorage.AudioClipsCount)
        {
            _clipIndex = 0;
        }
        else if (_clipIndex < 0)
        {
            _clipIndex = _cowbellsStorage.AudioClipsCount - 1;
        }

        _audioSource.clip = _cowbellsStorage.GetAudioClip(_clipIndex);

        ClipChanged?.Invoke(_clipIndex);
    }
}
