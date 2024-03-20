using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TableTextAnim : MonoBehaviour
{
    [SerializeField] private GameObject _checkpointText;
    [SerializeField] private Transform _textTransform;
    [SerializeField] private Vector3 _endValue;
    [SerializeField] private float _duration;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();

        if (player != null)
            OnCollisionAction();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();

        if (player != null)
            ExitCollisionAction();
    }
    public void OnCollisionAction()
    {
        _checkpointText.SetActive(true);
        _textTransform.DOScale(_endValue, _duration).SetEase(Ease.InOutBounce);
        _audioSource.PlayOneShot(_audioSource.clip);        
    }

    public void ExitCollisionAction()
    {
        _audioSource.mute = true;
    }

}
