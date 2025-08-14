using UnityEngine;

public readonly struct Intent
{
    public readonly int x, y;
    public readonly Ant ant;
    public readonly IAction action;

    public Intent(int x, int y, Ant ant, IAction action)
    {
        this.x = x;
        this.y = y;
        this.ant = ant;
        this.action = action;
    }
}
