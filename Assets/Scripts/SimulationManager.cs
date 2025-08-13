using System;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance;
    public Grid grid;
    [SerializeField] public int x, y;
    [SerializeField] CellType[] pool;
    public Action MapUpdate;
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        
        Instance = this;

        grid = new(x, y, pool);
    }

    void GenerateMap()
    {
        grid = new Grid(x, y, pool);
        if(MapUpdate != null) MapUpdate();
    }

}
