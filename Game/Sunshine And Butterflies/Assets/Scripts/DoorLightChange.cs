using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightChange : MonoBehaviour
{
    [SerializeField] private Color activationColor;

    private Renderer lightRenderer = null;
    private MaterialPropertyBlock propertyBlock = null;


    private void Start()
    {
        lightRenderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
    }

    public void ChangeEmission(float strength)
    {

        lightRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_EmissionColor", activationColor * (strength * 3));
        lightRenderer.SetPropertyBlock(propertyBlock);

    }

   
}
