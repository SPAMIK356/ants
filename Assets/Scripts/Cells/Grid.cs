using System.Diagnostics.Tracing;
using UnityEngine;

public class Grid 
{

    int x, y;
    public Cell[,] cells;
    public Grid (int x, int y, CellType[] pool)
    {
        this.x = x;
        this.y = y;
        cells = new Cell[x, y];

        float weightSum = 0;
        foreach (CellType cellType in pool) 
        {
            weightSum += cellType.weight;
        }
            
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                float choise = Random.Range(0.0f, weightSum);
                float sum = 0.0f;
                foreach (CellType cellType in pool)
                {
                    sum += cellType.weight;
                    if (sum > choise)
                    {
                        cells[i, j] = new Cell(cellType, i, j);
                        break;
                    }
                }
            }
        }
    }
}
