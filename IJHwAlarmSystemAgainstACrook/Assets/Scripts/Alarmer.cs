using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class Alarmer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0;
    private float _maxVolume = 1f;
    private float _speedVolume = 0.1f;
    private float _currentVolume;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _audioSource.loop = true;
        _audioSource.playOnAwake = false;
    }

    public void RunIncreaseAlarm()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(nameof(ControlVolume));

        _audioSource.Play();
    }

    public void RunDecreaseAlarm()
    {
        int tempForDecrease = -1;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _maxVolume = _minVolume;
        _minVolume = _currentVolume;

        _speedVolume *= tempForDecrease;

        _coroutine = StartCoroutine(nameof(ControlVolume));

        _audioSource.Play();
    }

    private IEnumerator ControlVolume()
    {
        float currentMin = _minVolume;
        float currentMax = _maxVolume;
        float currentSpeed = _speedVolume;

        _currentVolume = Mathf.MoveTowards(currentMin, currentMax,
            currentSpeed);

        _audioSource.volume = _currentVolume;
        //delete then
        print(_audioSource.volume);

        yield return new WaitUntil(() => _currentVolume == _minVolume
        || _currentVolume == _maxVolume);
    }
}
