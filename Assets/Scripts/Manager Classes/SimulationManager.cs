using System;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance;
    public Grid grid;
    [SerializeField] public int x, y;
    [SerializeField] CellType[] pool;
    public Action MapUpdate;
    public List<Ant> ants;
    [SerializeField] AntTemplate template;
    private void Awake()
    {
        ants = new List<Ant>();
        if (Instance != null) Destroy(this);
        
        Instance = this;

        grid = new(x, y, pool);
        ants.Add(new Ant(template, 0, 0));
        grid.cells[0,0].SetAnt(ants[0]);
    }
    private void Update()
    {
        List<Intent> intents = new();
        foreach (Cell cell in grid.cells) 
        { 
            cell.Update();
            if (cell.hasAnt)
            {
                var worldViews = new List<WorldView>();
                int i = 0;
                int ax = cell.x;
                int ay = cell.y;
                for (int dx = -1; dx <= 1; dx++) 
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if(dx==0  && dy==0) continue;
                        if(ax+dx<0 || ax+dx>=x || ay+dy<0 ||ay+dy>=y) continue;
                        worldViews.Add(grid.cells[ax + dx, ay + dy].CellToWorldView());
                        i++;
                    }
                }
                
                intents.Add(cell.ant.Decide(worldViews.ToArray()));
            }
        }
        foreach (Intent intent in intents) 
        {
            intent.action.DoAction(intent, grid.cells[intent.x, intent.y], grid.cells[intent.ant.x, intent.ant.y]);
        }
    }
    void GenerateMap()
    {
        grid = new Grid(x, y, pool);
        if(MapUpdate != null) MapUpdate();
    }

}
