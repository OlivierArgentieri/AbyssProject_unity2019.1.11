using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private float m_camera_sensibility;
    [SerializeField] private float m_distance_camera;
    private Vector2 m_moveVector2_;
    [SerializeField] private GameObject m_player;
    private InputMap m_inputMap_;
    
    private void Awake()
    {
         
    }

    // Update is called once per frame
    private void Update()
    {
       /* yaw += m_moveVector2_.x * m_camera_sensibility;
        pitch -= m_moveVector2_.y * m_camera_sensibility;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch); 
        
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        */
        
        this.transform.localRotation = Quaternion.Euler(Mathf.Clamp(m_moveVector2_.y, -100, 100)*-1 * m_camera_sensibility, m_moveVector2_.x * m_camera_sensibility, 0);
        this.transform.localPosition = m_player.transform.position - (this.transform.localRotation * Vector3.forward * m_distance_camera);
        VerticalRotation();
    }

    private void VerticalRotation()
    {
        
    }
    

    private void OnEnable()
    {
        if(m_inputMap_ == null)
            m_inputMap_ = new InputMap();
        
        m_inputMap_.Camera.TPS.performed += HandleTps;
        m_inputMap_.Camera.TPS.Enable();
    }

    private void OnDisable()
    {
        m_inputMap_.Camera.TPS.performed -= HandleTps;
        m_inputMap_.Camera.TPS.Disable();
    }

    private void HandleTps(InputAction.CallbackContext _obj)
    {
        m_moveVector2_ = _obj.ReadValue<Vector2>();
    }

   
}
