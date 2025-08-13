using UnityEngine;

public class RenderingManager : MonoBehaviour
{
    public static RenderingManager Instance;
    [SerializeField] Renderer map;

    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
    }

}
