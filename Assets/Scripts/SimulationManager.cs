using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(this);

        Instance = this;
    }
}
