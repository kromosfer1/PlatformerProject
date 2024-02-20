using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartElement : MonoBehaviour
{
    public Sprite FullHeart, EmptyHeart;
    public Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartStatus(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = EmptyHeart; break;
            case HeartStatus.Full:
                heartImage.sprite = FullHeart; break;
        }
    }
}
 public enum HeartStatus
{
    Empty = 0,
    Full = 1
}