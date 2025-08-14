using UnityEngine;

[CreateAssetMenu(fileName = "AntTemplate", menuName = "Scriptable Objects/AntTemplate")]
public class AntTemplate : ScriptableObject
{
    [SerializeField] public Color color;
    [SerializeField] public float maxFood;
}
