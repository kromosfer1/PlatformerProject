using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPcInputs : MonoBehaviour, IPlayerInputs
{
    public bool DownInput { get; private set; }
    public bool InteractInput { get; private set; }

    void FixedUpdate()
    {
        InputGather();
    }

    public void InputGather()
    {
        DownInput = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        InteractInput = Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Return);
    }
}
