using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private GameObject player;
    Vector3 target;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
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
