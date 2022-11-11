using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private int _time = 10;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = _minVolume;
    }

    public float GetMaxVolume() => _maxVolume;
    public float GetMinVolume() => _minVolume;

    public void Signal(float value)
    {
        _coroutine = StartCoroutine(ChangeVolume(value));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        var waitForSeconds = new WaitForSeconds(0.5f);
        float scale = _maxVolume / _time;

        if (_audioSource.volume <= _minVolume)
        {
            _audioSource.Play();
        }

        for (int i = 0; i < _time; i++)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, scale);

            if (_audioSource.volume <= _minVolume)
            {
                _audioSource.Stop();
            }

            yield return waitForSeconds;
        }
    }
}
