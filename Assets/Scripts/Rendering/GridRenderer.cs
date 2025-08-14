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
    public GridRenderer(int resX, int resY, Renderer renderer, FilterMode filterMode = FilterMode.Point, bool enableRendering = true)
    {
        normalised = new float[resX * resY];
        this.renderer = renderer;
        x = resX; y = resY;
        texture = new Texture2D(resX, resY);
        texture.filterMode = filterMode;
        this.renderer.material.mainTexture = texture;
        colors = new Color[x * y];
        renderingEnabled = enableRendering;
        renderer.enabled = renderingEnabled;
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
    public void Render(float[] values, int channel, float max = 1, float min = 0, float alpha = 1)
    {
        if(!renderingEnabled) return; 
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

            normalised = values;
            
        }

        switch (channel)
        {
            case 0:
                for(int i = 0; i < colors.Length; i++)
                {
                    colors[i] =  new Color(normalised[i],0,0,alpha);
                }

                break;
            case 1:
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i] = new Color(0,normalised[i], 0, alpha);


                }
                break;
            case 2:
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i] = new Color(0,0,normalised[i], alpha);


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
