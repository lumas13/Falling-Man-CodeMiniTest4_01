using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerOb : MonoBehaviour
{
    private float xLimitUpper = 150f;
    private float xLimitLower = 135f;
    private float speed = 8f;

    bool isDefault = true;
    bool isBack = false;

    // Start is called before the first frame update
    void Start()
    {    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefault == true && isBack == false)
        {
            if (transform.position.z <= xLimitUpper)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                isBack = true;
                isDefault = false;
            }
        }

        if (isBack == true && isDefault == false)
        {
            if (transform.position.z >= xLimitLower)
            {
                transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            }
            else
            {
                isDefault = true;
                isBack = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(0f, 1.2f, 133f);
        }

        if (collision.gameObject.CompareTag("FallingBalls"))
        {
            Destroy(collision.gameObject);
        }
    }
}
