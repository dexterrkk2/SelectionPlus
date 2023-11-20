using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] private List<Transform> selectables;
    [SerializeField] private float threshhold = .97f;
    private Transform _selection;
    public void Check(Ray ray)
    {
        float closest = 0f;
        _selection = null;
        for (int i = 0; i < selectables.Count; i++)
        {
            var vector1 = ray.direction;
            var vector2 = selectables[i].position - ray.origin;
            var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);
            if(lookPercentage > threshhold && lookPercentage > closest)
            {
                closest = lookPercentage;
                _selection = selectables[i];
            }
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }
}
