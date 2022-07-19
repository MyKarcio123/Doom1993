using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
