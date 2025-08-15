using UnityEngine;

public class Move : IAction
{
    public void DoAction(Intent intent, Cell targetCell, Cell startCell)
    {
        if(intent.ant.hasFood)
        {
            startCell.foodPheromone += intent.ant.DropFoodPheromones();
        }
        else
        {
            startCell.homePheromone += intent.ant.DropHomePheromones();
        }
            startCell.RemoveAnt();
        targetCell.SetAnt(intent.ant);
        intent.ant.x = intent.x;
        intent.ant.y = intent.y;
    }
}
