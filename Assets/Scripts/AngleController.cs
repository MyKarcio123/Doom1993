using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public Transform player;
    private Vector3 playerForward;
    private Vector3 myForward;
    private Vector3 side;
    private float dir;
    private float angle;
    private int index = 1;

    void Update()
    {
        GetVectors();
        RotateSprite();
        SetSprite();
    }
    void GetVectors()
    {
        playerForward = player.forward;
        myForward = new Vector3(player.position.x, transform.position.y, player.position.z);
        myForward -= transform.position;
        angle = Vector3.Angle(transform.position, myForward);
        index = GetIndex(angle);
    }
    void RotateSprite()
    {
        side = Vector3.Cross(transform.position, myForward);
        dir = Vector3.Dot(side, Vector3.up);
        if (dir >= 0.0f || index==0 || index==4)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
    void SetSprite()
    {
        spriteRenderer.sprite = sprites[index];
    }
    int GetIndex(float angle)
    {
        if (angle <= 22.5f) return 0;
        else if (22.5f < angle && angle <= 67.5f) return 1;
        else if (67.5f < angle && angle <= 112.5f) return 2;
        else if (112.5f < angle && angle <= 157.5f) return 3;
        else return 4;
    }
}
