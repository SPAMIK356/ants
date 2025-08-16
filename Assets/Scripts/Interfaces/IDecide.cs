using UnityEngine;

public abstract class IDecide : ScriptableObject
{
    public abstract Intent Decide(WorldView[] worldViews, Ant ant);
}
