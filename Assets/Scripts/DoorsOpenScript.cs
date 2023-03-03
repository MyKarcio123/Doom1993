using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpenScript : MonoBehaviour
{
    public float maxHeight;
    public float doorSpeed;
    public float doorWait;
    public AudioClip openClip;
    public AudioClip closeClip;
    private AudioSource audioSource;
    private float startedY;
    private float speed;
    bool opening = false;
    bool sliding_down = false;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        startedY = gameObject.transform.position.y;
    }
    public void openDoors()
    {
        if (!opening)
        {
            Debug.Log("Yes");
            opening = true;
            StartCoroutine(goUp());
        }
     }
    IEnumerator goUp()
    {
        audioSource.clip = openClip;
        audioSource.Play();
        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;
        while (gameObject.transform.position.y < maxHeight)
        {
            //speed = doorSpeed * Time.deltaTime;
            gameObject.transform.position = new Vector3(x, gameObject.transform.position.y + doorSpeed, z) ;
            yield return null;
        }
        gameObject.transform.position = new Vector3(x, maxHeight, z);
        yield return StartCoroutine(wait());
    }
    IEnumerator goDown()
    {
        sliding_down = true;
        audioSource.clip = closeClip;
        audioSource.Play();
        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;
        while (gameObject.transform.position.y > startedY)
        {
            speed = doorSpeed * Time.deltaTime;
            gameObject.transform.position = new Vector3(x, gameObject.transform.position.y - doorSpeed, z);
            yield return null;
        }
        gameObject.transform.position = new Vector3(x, startedY, z);
        opening = false;
        sliding_down = false;
        yield break;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(doorWait);
        StartCoroutine(goDown());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (sliding_down)
        {
            sliding_down = false;
            StopAllCoroutines();
            StartCoroutine(goUp());
        }
        Debug.Log("hey");
    }
}
