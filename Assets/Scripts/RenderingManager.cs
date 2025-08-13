using UnityEngine;
using System.Linq;
public class RenderingManager : MonoBehaviour
{
    public static RenderingManager Instance;
    [SerializeField] Renderer map;
    [SerializeField] Renderer pheromoneMap;
    GridRenderer gridRenderer;

    GridRenderer pheromoneRenderer;
    [Range(0.0f, 1.0f)] [SerializeField] float pheromoneLayerAlpha = 0.2f;

    SimulationManager simulationManager;

    float[] pheromones;
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
    }
    private void Start()
    {
        simulationManager = SimulationManager.Instance;
        gridRenderer = new(simulationManager.x, simulationManager.y,map);
        pheromoneRenderer = new(simulationManager.x,simulationManager.y,pheromoneMap,enableRendering:false);
        simulationManager.MapUpdate += MapUpdated;
        pheromones = new float[simulationManager.x*simulationManager.y];
    }
    private void Update()
    {
        int i = 0;
        foreach(var c in simulationManager.grid.cells)
        {
            pheromones[i++] = c.foodPheromone;
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt)) gridRenderer.SetRendering(!gridRenderer.renderingEnabled);
        if(Input.GetKeyDown(KeyCode.RightAlt)) pheromoneRenderer.SetRendering(!pheromoneRenderer.renderingEnabled);

        gridRenderer.Render(simulationManager.grid.cells);
        pheromoneRenderer.Render(pheromones,0,alpha:pheromoneLayerAlpha);
    }

    private void MapUpdated()
    {
        gridRenderer = new(simulationManager.x, simulationManager.y, map);

    }

}
