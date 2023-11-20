using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{
    public Transform player;
    public bool enable;
    public float moveSpeed;
    public MeshRenderer meshRanderer;
    private void Start()
    {
        enable = true;
    }
    // Update is called once per frame
    public void Move()
    {
        Vector3 Direction = transform.position - player.position;
        transform.Translate(-Direction/moveSpeed);
    }
    public void FixedUpdate()
    {
        if (enable)
        {
            Move();
        }
    }
}
