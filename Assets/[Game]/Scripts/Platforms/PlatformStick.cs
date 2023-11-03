using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IPlayerController player = collision.gameObject.GetComponent<IPlayerController>();
        if (player != null)
        {
            collision.transform.SetParent(null);
        }
    }
}
