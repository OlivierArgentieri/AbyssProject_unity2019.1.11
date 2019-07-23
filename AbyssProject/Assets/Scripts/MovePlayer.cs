using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Vector2 _moveVector2_;
    private InputMap _inputMap_;


    private void Awake()
    {
        _inputMap_ = new InputMap();
    }


    private void Update()
    {
        this.transform.position += new Vector3( _moveVector2_.x, 0, _moveVector2_.y) * _moveSpeed * Time.deltaTime;
    }


    private void OnEnable()
    {
        _inputMap_.Player.Move.performed += HandleMove;
        _inputMap_.Player.Move.Enable();
    }

    private void OnDisable()
    {
        _inputMap_.Player.Move.performed -= HandleMove;
        _inputMap_.Player.Move.Disable();
    }

    private void HandleMove(InputAction.CallbackContext obj)
    {
        _moveVector2_ = obj.ReadValue<Vector2>();
        Debug.Log("moved");
    }
}