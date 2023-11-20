using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public Material highlightMaterial;
    public Material defaultMaterial;
    // Start is called before the first frame update
    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = defaultMaterial;
        }
    }
    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = highlightMaterial;
        }
    }
}
