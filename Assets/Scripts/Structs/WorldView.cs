using UnityEngine.UI;

public readonly struct WorldView
{
    public readonly int x, y;
    public readonly bool isPasable;
    public readonly float foodPheromone, homePheromone, foodAmount;
    public readonly CellFlag cellType;

    public WorldView(int x, int y, bool isPasable, float foodPheromone, float homePheromone, CellFlag cellType, float foodAmount)
    {
        this.x = x;
        this.y = y;
        this.isPasable = isPasable;
        this.foodPheromone = foodPheromone;
        this.homePheromone = homePheromone;
        this.cellType = cellType;
        this.foodAmount = foodAmount;
    }
}
