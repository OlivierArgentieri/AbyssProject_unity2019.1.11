using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string m_name;
    public string m_description;
    public GameObject m_item_display;
}