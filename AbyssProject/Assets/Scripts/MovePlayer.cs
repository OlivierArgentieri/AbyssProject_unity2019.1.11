using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private InputMap _inputMap;


    private void OnEnable()
    {
        _inputMap.Player.Move.performed += Move;
    }

    private void OnDisable()
    {
        _inputMap.Player.Move.performed -= Move;
    }

    private void Move(InputAction.CallbackContext obj)
    {
        Debug.Log("moved");
    }
}