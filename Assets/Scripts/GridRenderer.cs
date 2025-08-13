using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GridRenderer
{
    Texture2D texture;
    Renderer renderer;
    int x, y;
    Color[] colors;
    float[] normalised;
    public bool renderingEnabled { get; private set;} = true;
    public GridRenderer(int resX, int resY, Renderer renderer)
    {
        normalised = new float[resX * resY];
        this.renderer = renderer;
        x = resX; y = resY;
        texture = new Texture2D(resX, resY);
        this.renderer.material.mainTexture = texture;
        colors = new Color[x * y];
    }
    public void SetRendering(bool state)
    {
        renderingEnabled = state;
        renderer.enabled = renderingEnabled;
    }
    public void Render(Cell[,] cells)
    {
        int i = 0;
        foreach (var cell in cells)
        {
            colors[i++] = cell.color;
        }
        texture.SetPixels(colors);
        texture.Apply();
    }
    public void Render(float[,] values, int channel, float max = 1, float min = 0)
    {
        if(max!=1 ||  min!=0)
            if (min == 0)
            {
                int i = 0;
                foreach (var value in values)
                {
                    normalised[i++] = value / max;
                }
            }
            else
            {
                int i = 0;
                foreach (var value in values)
                {
                    normalised[i++] = (value - min)/ (max - min);
                }
            }
        else
        {
            int i = 0;
            foreach (var value in values)
            {
                normalised[i++] = value;
            }
        }

        switch (channel)
        {
            case 0:
                for(int i = 0; i < colors.Length; i++)
                {
                    colors[i].r = normalised[i];
                    colors[i].g = 0;
                    colors[i].b = 0;
                }

                break;
            case 1:
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i].r = 0; 
                    colors[i].g = normalised[i];
                    colors[i].b = 0;
                }
                break;
            case 2:
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i].r = 0;
                    colors[i].g = 0;
                    colors[i].b = normalised[i];
                }
                break;
            default:
                Debug.LogError("Wrong channel value!");
                throw new System.Exception();
        }

        texture.SetPixels(colors);
        texture.Apply();
    }
}
