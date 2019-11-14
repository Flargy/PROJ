using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightChange : MonoBehaviour
{
    [SerializeField] private Color activationColor;

    private Renderer lightRenderer = null;
    private MaterialPropertyBlock propertyBlock = null;
    private Color startColor = Color.red;


    private void Start()
    {
        lightRenderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        startColor = GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
    }

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
