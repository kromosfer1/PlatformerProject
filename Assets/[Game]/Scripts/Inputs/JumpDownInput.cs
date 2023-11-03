using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDownInput : MonoBehaviour
{
    public bool hopDownInput;

    private void Update()
    {
        InputGather();
    }

    public void InputGather()
    {
        hopDownInput = Input.GetKey(KeyCode.S);
    }
}
