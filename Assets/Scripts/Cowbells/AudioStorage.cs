using System.Collections.Generic;
using UnityEngine;

public class AudioStorage : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;

    public int AudioClipsCount => _audioClips.Count;

    public AudioClip GetAudioClip(int number)
    {
        if (number >= 0 && number < _audioClips.Count)
        {
            return _audioClips[number];
        }

        return null;
    } 
}
