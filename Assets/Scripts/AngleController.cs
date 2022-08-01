using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public Transform player;
    public int index;
    private Vector3 myForward;
    private float angle;

    void Update()
    {
        GetVectors();
        RotateSprite();
        SetSprite();
    }
    void GetVectors()
    {
        myForward = new Vector3(player.position.x, transform.position.y, player.position.z);
        myForward -= transform.position;
        angle = Vector3.SignedAngle(myForward, transform.forward,Vector3.up);
        index = GetIndex(angle);
    }
    void RotateSprite()
    {
        if (angle<0 && index!=0 && index!=4)
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
        if (angle >= -22.5 && angle <= 22.5f) return 0;
        else if ((22.5f < angle && angle <= 67.5f) || (-22.5f > angle && angle >= -67.5f)) return 1;
        else if ((67.5f < angle && angle <= 112.5f) || (-67.5f > angle && angle >= -112.5f))return 2;
        else if ((112.5f < angle && angle <= 157.5f) || (-112.5f > angle && angle >= -157.5f))return 3;
        else return 4;
    }
}
