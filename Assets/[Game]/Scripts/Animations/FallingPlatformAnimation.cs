using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FallingPlatformAnimation : MonoBehaviour
{
    private FallingPlatform fallingPlatform => GetComponentInParent<FallingPlatform>();

    [Header("ANIMATION STATS")]
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeStrength;
    [SerializeField] private float _randomness;
    [SerializeField] private int _vibrato;

    private void OnEnable()
    {
        fallingPlatform.FallStart += PlatformAnimation;
    }
    private void OnDisable()
    {
        fallingPlatform.FallStart -= PlatformAnimation;
    }
    private void PlatformAnimation()
    {
        StartCoroutine(PlatformAnimCoroutine());       
    }

    IEnumerator PlatformAnimCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        transform.DOShakePosition(_shakeDuration, _shakeStrength, _vibrato, _randomness);
    }
}
