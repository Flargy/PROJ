using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Marcus Lundqvist

public class DoorLightChange : MonoBehaviour
{
    [SerializeField] private Color activationColor;

    private Renderer lightRenderer = null;
    private MaterialPropertyBlock propertyBlock = null;
    private Color startColor = Color.red;

    /// <summary>
    /// Sets values to variables on startup.
    /// </summary>
    private void Start()
    {
        lightRenderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        startColor = GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
    }

    /// <summary>
    /// Sets the emission color of the object depending on the value received.
    /// </summary>
    /// <param name="strength">The value of how strong the emission color will be.</param>
    public void ChangeEmission(float strength)
    {

        lightRenderer.GetPropertyBlock(propertyBlock);
        if(strength == 0)
        {
            propertyBlock.SetColor("_EmissionColor", startColor);
        }
        else
        {
            propertyBlock.SetColor("_EmissionColor", activationColor * (strength * 3));

        }
        lightRenderer.SetPropertyBlock(propertyBlock);

    }

   
}
