using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField] private float _firstvalue;
    [SerializeField] private float _endvalue;
    [SerializeField] private float _duration;
    private void Start()
    {
        StartCoroutine(AnimationSequence(2));
    }

    private IEnumerator AnimationSequence(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        transform.DOScale(_firstvalue, _duration).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(4);
        transform.DOScale(_endvalue, _duration).SetEase(Ease.OutBack);
    }
}
