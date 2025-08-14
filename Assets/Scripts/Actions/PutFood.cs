
public class PutFood : IAction
{
    public void DoAction(Intent intent, Cell targetCell, Cell startCell)
    {
        targetCell.PutFood(intent.ant.GiveFood());
    }

}
