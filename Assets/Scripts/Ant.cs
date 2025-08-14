using UnityEngine;

public class Ant
{
    private bool hasFood = false;
    public bool HasFood { get
        {

            return hasFood;
        } private set { 
            hasFood = value;
        } }
    float foodPheromone = 0;
    float foodAmount = 0;
    float maxFood;
    public Color color;
    
}
