using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSelection : MonoBehaviour, ISelectionResponse
{
    private Creep npc;
    public Color OnSelected;
    public Color deselectedColor;
    public ILazer lazer;
    public GameObject lazerHolder;
    void Start()
    {
        lazer = lazerHolder.GetComponent<ILazer>();
        lazer.CreateLazer();
    }
    public void OnDeselect(Transform selection)
    {
        npc = selection.gameObject.GetComponent<Creep>();
        if (npc != null)
        {
            lazer.Off();
            npc.enabled = true;
            npc.meshRanderer.material.color = deselectedColor;
        }
    }

    public void OnSelect(Transform selection)
    {
        npc = selection.gameObject.GetComponent<Creep>();
        if (npc != null)
        {
            lazer.On();
            lazer.MoveLazer(selection);
            npc.enabled = false;
            npc.meshRanderer.material.color = OnSelected;
        }
    }
}
