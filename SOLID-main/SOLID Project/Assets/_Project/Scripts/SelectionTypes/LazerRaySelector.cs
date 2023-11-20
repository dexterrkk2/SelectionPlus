using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerRaySelector : MonoBehaviour, ISelectionResponse
{
    public IRayProvider ray;
    public ILazer lazer;
    public GameObject lazerHolder;
    void Start()
    {
        lazer = lazerHolder.GetComponent<ILazer>();
        lazer.CreateLazer();
    }
    public void OnDeselect(Transform selection)
    {
        lazer.Off();
    }
    public void OnSelect(Transform selection)
    {
        lazer.On();
        lazer.MoveLazer(selection);
        lazer.LazerEffect(selection);
    }
}
