using UnityEngine;

public class Cell
{
    public int x, y;
    private Color baseColor;
    public Color color;
    public bool hasAnt;
    public bool isPasable;
    public float food;
    public float foodPheromone;
    public float homePheromone;
    public CellFlag cellFlag;
    public Ant ant;
    public Cell(CellType cellType, int x, int y)
    {
        color = cellType.color;
        baseColor = cellType.color;
        isPasable = cellType.isPasable;
        food = cellType.food;
        cellFlag = cellType.cellFlag;
        this.x = x;
        this.y = y;
    }
    public void RemoveAnt()
    {
        ant = null;
        hasAnt = false;
        color = baseColor;
    }
    public void SetAnt(Ant ant)
    {
        if (ant == null) 
        {
            Debug.LogWarning($"Trying to set empty ant to cell with cords {x} {y}");
            return; 
        }
        this.ant = ant;
        hasAnt = true;
        color = ant.color;
    }
    public float GetFood(float maxFood)
    {
        if(cellFlag != CellFlag.FoodSource)
        {
            Debug.LogWarning($"Trying to get food from non-source! Cords are {x} {y}");
            return 0;
        }
        float getAmount = Mathf.Clamp(maxFood, 0, food);
        food-= getAmount;
        if(food <= 0)
        {
            cellFlag = CellFlag.Regular;
        }
        return getAmount;
    }
    public void PutFood(float amount)
    {
        if (cellFlag == CellFlag.Nest)
        {
            Debug.LogWarning($"Trying to put food into non-nest cell on cords {x} {y}!");
            return;
        }
        food += amount;
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
