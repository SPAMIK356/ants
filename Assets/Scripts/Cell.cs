using UnityEngine;

public class Cell
{
    public Color color;
    public bool hasAnt;
    public bool isPasable;
    public float food;
    public float foodPheromone;
    public float homePheromone;
    public CellFlag cellFlag;
    public Cell(CellType cellType)
    {
        color = cellType.color;
        isPasable = cellType.isPasable;
        food = cellType.food;
        cellFlag = cellType.cellFlag;
    }
}

public enum CellFlag
{
    Regular,
    Nest,
    FoodSource
}
