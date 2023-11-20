using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILazer
{
    void CreateLazer();
    void MoveLazer(Transform selection);
    void LazerEffect(Transform selection);
    void On();
    void Off();
}
