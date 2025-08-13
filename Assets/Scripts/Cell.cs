using UnityEngine;

public class Cell : MonoBehaviour
{
    public Color color;
    public bool hasAnt;
    public bool isPasable;
    public float food;
    public float foodPheromone;
    public float homePheromone;

    public Cell(CellType cellType)
    {
        color = cellType.color;
        isPasable = cellType.isPasable;
        food = cellType.food;
    }
}
