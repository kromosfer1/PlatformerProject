using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPcInputs : MonoBehaviour, IPlayerInputs
{
    public bool DownInput { get; private set; }

    void Update()
    {
        InputGather();
    }

    public void InputGather()
    {
        DownInput = Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow);
    }
}
