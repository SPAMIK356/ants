using UnityEngine;

public class Cell
{
    public int x, y;
    public Color color;
    public bool hasAnt;
    public bool isPasable;
    public float food;
    public float foodPheromone;
    public float homePheromone;
    public CellFlag cellFlag;
    public Cell(CellType cellType, int x, int y)
    {
        color = cellType.color;
        isPasable = cellType.isPasable;
        food = cellType.food;
        cellFlag = cellType.cellFlag;
        this.x = x;
        this.y = y;
    }

    public WorldView CellToWorldView()
    {
        return new WorldView(x,y,isPasable,foodPheromone,homePheromone,cellFlag,food);
    }
}

public enum CellFlag
{
    Regular,
    Nest,
    FoodSource
}
