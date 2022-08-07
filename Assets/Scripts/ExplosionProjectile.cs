using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProjectile : MonoBehaviour
{
    public float force=20f;
    public int damage = 3;
    private Animator animator;
    private Rigidbody rb;
    public GameObject parent;
    public GameObject target;
    private AudioSource audioSource;
    public AudioClip explosion;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        animator.Play("Default");
        rb.AddForce((new Vector3(target.transform.position.x, target.transform.position.y + 0.5f, target.transform.position.z) - gameObject.transform.position).normalized*force, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != parent)
        {
            rb.isKinematic = true;
            Destroy(gameObject.GetComponent<Collider>());
            animator.Play("Explode");
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().GetHit(damage);
            }
            else if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyHP>().dealDamage(damage);
            }
        }
    }
    private void end()
    {
        audioSource.clip = explosion;
        audioSource.Play();
    }
    private void explode()
    {
        Destroy(gameObject);
    }
}
