using UnityEngine;

public class RenderingManager : MonoBehaviour
{
    public static RenderingManager Instance;
    [SerializeField] Renderer map;
    GridRenderer gridRenderer;
    SimulationManager simulationManager;
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
    }
    private void Start()
    {
        simulationManager = SimulationManager.Instance;
        gridRenderer = new(simulationManager.x, simulationManager.y,map);
        simulationManager.MapUpdate += MapUpdated;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt)) gridRenderer.SetRendering(!gridRenderer.renderingEnabled);

        if (gridRenderer.renderingEnabled) gridRenderer.Render(simulationManager.grid.cells);
    }

    private void MapUpdated()
    {
        gridRenderer = new(simulationManager.x, simulationManager.y, map);

    }

}
