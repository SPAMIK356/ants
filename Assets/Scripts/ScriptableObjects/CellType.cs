using UnityEngine;

[CreateAssetMenu(fileName = "CellType", menuName = "Scriptable Objects/CellType")]
public class CellType : ScriptableObject
{
    [SerializeField]
    public float weight = 1f;
    [SerializeField]
    public Color color;
    [SerializeField]
    public bool isPasable;
    [SerializeField]
    public float food;
    [SerializeField]
    public CellFlag cellFlag;

}
