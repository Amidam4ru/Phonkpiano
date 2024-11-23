using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeSetter : MonoBehaviour
{
    [SerializeField] private List<LoopSwitch> _loopSwitches;
    [SerializeField] private List<AudioSource> _audioSources; 

    private void OnEnable()
    {
        foreach (LoopSwitch loopSwitch in _loopSwitches)
        {
            loopSwitch.Switched += AnnounceTime;
        }
    }

    private void OnDisable()
    {
        foreach (LoopSwitch loopSwitch in _loopSwitches)
        {
            loopSwitch.Switched -= AnnounceTime;
        }
    }

    private void AnnounceTime(float time)
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.Play();
            Debug.Log(audioSource.time);
            audioSource.time = time;
        }
    }
}
