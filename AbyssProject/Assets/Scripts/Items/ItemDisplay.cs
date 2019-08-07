using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Item m_item;
    void OnValidate()
    {
        Debug.Log(m_item.m_name); 
        Debug.Log(m_item.m_description);
    }
}
