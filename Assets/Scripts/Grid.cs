using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] int x, y;
    [SerializeField] bool render = true;
    Cell[,] cells;
    Color[]  colors;
    Texture2D texture;
    private void Awake()
    {
        colors = new Color[x * y];
        texture = new Texture2D(x, y);
        texture.filterMode = FilterMode.Point;
        rend.material.mainTexture = texture;

    }
    private void Update()
    {
        if(render) Render(cells,texture,rend);
    }

    void Render(Cell[,] cells, Texture2D texture, Renderer rend)
    {
        int i = 0;
        foreach (var cell in cells) {
            colors[i++] = cell.color;
        }
        texture.SetPixels(colors);
        texture.Apply();
    }


}
