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
    private float _delay = 0.5f; 

    private void Awake()
    {
        _audioSource.loop = true;
        _audioSource.playOnAwake = false;

        _wait = new WaitForSeconds(_delay);
    }

    public void RunIncreaseAlarm()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ControlVolume(_maxVolume));

        _audioSource.Play();
    }

    public void RunDecreaseAlarm()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ControlVolume(_minVolume));

        _audioSource.Play();
    }

    private IEnumerator ControlVolume(float target)
    {
        while (!Mathf.Approximately(_currentVolume, target))
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, target,
                _speedVolume);

            _audioSource.volume = _currentVolume;

            yield return _wait;
        }
    }
}
