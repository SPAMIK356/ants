using UnityEngine;

public class Ant
{
    private float pheromoneDropRate = 0.1f;
    public bool hasFood { get; private set; } = false;
  
    public float foodPheromone = 0;
    public float homePheromone = 0;
    float foodAmount = 0;
    public float maxFood { get; private set; }
    public Color color;
    public int x, y;
    public Ant(AntTemplate template, int x, int y)
    {
        color = template.color;
        maxFood = template.maxFood;
        this.x = x;
        this.y = y;
    }
    public float GetFood(float sourceFoodAmount)
    {
        if (sourceFoodAmount <= 0) 
        {
            Debug.LogWarning($"Ant with cords {x} {y} trying to get food from empty source!");
            return 0; 
        }
        hasFood = true;
        foodAmount += Mathf.Clamp(sourceFoodAmount, 0, maxFood);
        foodPheromone = 1;
        return sourceFoodAmount-foodAmount;
        
    }
    public float GiveFood()
    {
        if (!hasFood)
        {
            Debug.LogWarning($"Ant with cords {x} {y} trying to give food despite not having it!");
            return 0;
        }

        var givenFood = foodAmount;
        foodAmount = 0;
        hasFood = false;
        return givenFood;
    }

    public float DropHomePheromones()
    {
        var pheromones = homePheromone*pheromoneDropRate;
        homePheromone -= pheromones;
        return pheromones;
    }
    public float DropFoodPheromones()
    {
        var pheromones = foodPheromone * pheromoneDropRate;
        foodPheromone -= pheromones;
        return pheromones;
    }
}
