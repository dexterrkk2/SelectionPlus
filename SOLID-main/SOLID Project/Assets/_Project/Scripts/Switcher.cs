using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public List<GameObject> changeableObjects;
    List<IChangeable> changeAbles = new List<IChangeable>();
    private void Start()
    {
        for (int i =0; i< changeableObjects.Count; i++)
        {
            IChangeable changeableObject = changeableObjects[i].GetComponent<IChangeable>();
            changeAbles.Add(changeableObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            for(int i =0; i<changeAbles.Count; i++)
            {
                changeAbles[i].Next();
            }
        }
    }
}
