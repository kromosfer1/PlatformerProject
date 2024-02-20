using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHUDControl : MonoBehaviour
{
    public GameObject HeartPrefab;
    PlayerHealthController playerHealth;
    List<HeartElement> hearts = new List<HeartElement>();

    private CharacterEventHandler eventHandler;
    private CharacterEventHandler EventHandler => eventHandler ?? FindAnyObjectByType<CharacterEventHandler>();
    private void Start()
    {
        playerHealth = (PlayerHealthController)FindObjectOfType(typeof(PlayerHealthController));

        if (playerHealth == null)
        {
            Debug.LogError("Couldn't find an object implementing IPlayerHealth!");
        }

        DrawHearts();
    }

    private void OnEnable()
    {
        EventHandler.OnDamageTaken.AddListener(DrawHearts);
        EventHandler.OnCharacterRevive.AddListener(DrawHearts);
    }

    private void OnDisable()
    {
        EventHandler.OnDamageTaken.RemoveListener(DrawHearts);
        EventHandler.OnCharacterRevive.RemoveListener(DrawHearts);
    }
    public void DrawHearts()
    {
        ClearHearts();

        //determine how many hearts to make total based off max health (half health system)
        float maxHealthRemainder = playerHealth.MaxHealth % 2;
        int heartsToMake = (int)((playerHealth.MaxHealth/2) + maxHealthRemainder);

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0;i < hearts.Count;i++)
        {
            int heartStatusRemainder = Mathf.Clamp(playerHealth.CurrentHealth - (i*2),0,1);
            hearts[i].SetHeartStatus((HeartStatus)heartStatusRemainder);
        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(HeartPrefab);
        newHeart.transform.SetParent(transform);

        HeartElement heartComponent = newHeart.GetComponent<HeartElement>();
        heartComponent.SetHeartStatus(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HeartElement> ();
    }
}
