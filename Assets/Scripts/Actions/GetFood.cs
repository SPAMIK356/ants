public class GetFood : IAction
{
    float foodBeacon = 2f;
    public void DoAction(Intent intent, Cell targetCell, Cell currentCell) 
    {
        intent.ant.GetFood(targetCell.GetFood(intent.ant.maxFood));
        currentCell.foodPheromone += foodBeacon;
    }
}
