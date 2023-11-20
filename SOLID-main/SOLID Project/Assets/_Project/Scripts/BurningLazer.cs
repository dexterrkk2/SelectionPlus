using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningLazer : MonoBehaviour, ILazer
{
    public LineRenderer lineRenderer;
    public float startWidth;
    public float endWidth;
    public float shrinkVar;
    public Transform start;
    public Color lazerColor;
    public float minScale;
    public void CreateLazer()
    {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.material.color = lazerColor;
    }

    public void LazerEffect(Transform selection)
    {
        shrink(selection);
    }
    public void shrink(Transform selection)
    {
        selection.localScale = new Vector3(selection.localScale.x/shrinkVar, selection.localScale.y / shrinkVar,selection.localScale.z/shrinkVar);
        if (selection.localScale.magnitude < minScale)
        {
            selection.gameObject.SetActive(false);
        }
    }
    public void MoveLazer(Transform selection)
    {
        lineRenderer.SetPosition(0, start.position);
        lineRenderer.SetPosition(1, selection.position);
    }

    public void On()
    {
        lineRenderer.enabled = true;
    }

    public void Off()
    {
        lineRenderer.enabled = false;
    }
}
