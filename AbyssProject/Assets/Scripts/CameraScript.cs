using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private float m_camera_sensibility;
    [SerializeField] private float m_distance_camera;
    private Vector2 _moveVector2_;
    [SerializeField] private GameObject m_player_;
    private InputMap _inputMap_;

    private void Awake()
    {
        _inputMap_ = new InputMap(); 
    }

    // Update is called once per frame
    private void Update()
    {
        this.transform.localRotation = Quaternion.Euler(Mathf.Clamp(_moveVector2_.y, -100, 100)*-1 * m_camera_sensibility, _moveVector2_.x * m_camera_sensibility, 0);
        this.transform.localPosition = m_player_.transform.position - (transform.localRotation * Vector3.forward * m_distance_camera);
    }

    private void OnEnable()
    {
        _inputMap_.Camera.TPS.performed += HandleTPS;
        _inputMap_.Camera.TPS.Enable();
    }

    private void OnDisable()
    {
        _inputMap_.Camera.TPS.performed -= HandleTPS;
        _inputMap_.Camera.TPS.Disable();
    }

    private void HandleTPS(InputAction.CallbackContext obj)
    {
        _moveVector2_ = obj.ReadValue<Vector2>();
    }
}
