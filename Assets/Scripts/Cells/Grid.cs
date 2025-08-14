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
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                cells[i, j] = new Cell(pool[Random.Range(0,pool.Length)],i,j);
            }
        }
    }
}
