using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float foodSpeed = 20;
    Rigidbody rb;
    AudioSource au;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        au = GetComponents<AudioSource>()[1];
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.position += Vector3.forward * foodSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cow") ||
            collision.gameObject.CompareTag("Dog") ||
            collision.gameObject.CompareTag("Horse") ||
            collision.gameObject.CompareTag("Deer"))
        {
            au.Play();
            Destroy(gameObject, 0.3f);
            Destroy(collision.gameObject);
        }
    }
}
