using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCubeColor : MonoBehaviour
{
    public float hueSpeed = 1.0f; // Speed of hue cycling
    private MaterialPropertyBlock propertyBlock;
    private Renderer cubeRenderer;
    private float hue = 0.25f;

    void Start()
    {
        // Get the cube's renderer
        cubeRenderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();

        // Set the initial color
        Color initialColor = Color.white;
        propertyBlock.SetColor("_Color", initialColor);
        cubeRenderer.SetPropertyBlock(propertyBlock);
    }

    void Update()
    {
        // Cycle through the hue
        hue += hueSpeed * Time.deltaTime;
        if (hue > 1.0f)
        {
            hue -= 1.0f;
        }

        // Calculate the new color
        Color newColor = Color.HSVToRGB(hue, 1.0f, 1.0f);

        // Set the new color using a MaterialPropertyBlock
        propertyBlock.SetColor("_Color", newColor);
        cubeRenderer.SetPropertyBlock(propertyBlock);
    }
}
