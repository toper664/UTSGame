using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public Rigidbody foodPrefab;
    [SerializeField] float mvtSpeed = 40;
    [SerializeField] float foodSpeed = 20;

    public static int Sign(float f)
    {
        if (f < 0f)
        {
            return -1;
        }
        else if (f > 0f)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetInteger("mvt", Sign(move));
        if (rb.position.x < -48 && move < 0)
        {
            rb.position = new Vector3(-48, rb.position.y, rb.position.z);
        }
        else if (rb.position.x > 54 && move > 0)
        {
            rb.position = new Vector3(54, rb.position.y, rb.position.z);
        }
        else
        {
            rb.position += move * Vector3.right * mvtSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("throw");
            Rigidbody food = Instantiate(foodPrefab, new Vector3(rb.position.x, rb.position.y, rb.position.z), Quaternion.identity);
            food.velocity = transform.TransformDirection(Vector3.forward * foodSpeed);
        }
    }
}
