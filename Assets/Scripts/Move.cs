using UnityEngine;

public class Move : IAction
{
    public void DoAction(Intent intent, Cell targetCell, Cell startCell)
    {
        startCell.RemoveAnt();
        targetCell.SetAnt(intent.ant);
        intent.ant.x = intent.x;
        intent.ant.y = intent.y;
    }
}
