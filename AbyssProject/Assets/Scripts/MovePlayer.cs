using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour, InputMap.IPlayerActions
{
    [SerializeField] private float m_moveSpeed;
    private Vector2 m_moveVector2_;
    private InputMap m_inputMap_;

    private void Update()
    {
        this.transform.position += new Vector3( m_moveVector2_.x, 0, m_moveVector2_.y) * m_moveSpeed * Time.deltaTime;
    }


    private void OnEnable()
    {
        if(m_inputMap_ == null)
            m_inputMap_ = new InputMap();
        m_inputMap_.Player.Move.performed += this.OnMove;
        m_inputMap_.Player.Move.Enable();
    }

    private void OnDisable()
    {
        m_inputMap_.Player.Move.performed -= this.OnMove;
        m_inputMap_.Player.Move.Disable();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        m_moveVector2_ = context.ReadValue<Vector2>();
        Debug.Log("moved");
    }
}