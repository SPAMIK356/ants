using UnityEngine;

public interface IAction
{
    public void DoAction(Intent intent, Cell targetCell);
}
