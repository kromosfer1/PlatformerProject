using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool downInput;
    void Update()
    {
        InputGather();
    }

    public void InputGather()
    {
        downInput = Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow);
    }
}
