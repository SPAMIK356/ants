using UnityEngine;

public class Ant
{
    private bool hasFood = false;
  
    float foodPheromone = 0;
    float foodAmount = 0;
    float maxFood;
    public Color color;
    public int x, y;
    public Ant(AntTemplate template, int x, int y)
    {
        color = template.color;
        maxFood = template.maxFood;
        this.x = x;
        this.y = y;
    }
}
