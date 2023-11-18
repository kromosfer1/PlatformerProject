using MovementController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        IPlayerInputs input = collision.gameObject.GetComponent<IPlayerInputs>();
       
        if (player != null)
        {
            if (input.InteractInput)
            {
                StartCoroutine(PlayerAnimator.Instance.PortalIn(collision,_destination));
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        IPlayerInputs input = collision.gameObject.GetComponent<IPlayerInputs>();
        
        if (player != null)
        {
            if (input.InteractInput)
            {
                StartCoroutine(PlayerAnimator.Instance.PortalIn(collision,_destination));
            }
        }
    }

    




}
