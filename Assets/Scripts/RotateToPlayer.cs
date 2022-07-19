using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 target;
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        target = player.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}
