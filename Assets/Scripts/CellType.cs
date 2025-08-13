using UnityEngine;

[CreateAssetMenu(fileName = "CellType", menuName = "Scriptable Objects/CellType")]
public class CellType : ScriptableObject
{
    [SerializeField]
    Color color;
    [SerializeField]
    bool isPasable;
    [SerializeField]
    float food;

}
