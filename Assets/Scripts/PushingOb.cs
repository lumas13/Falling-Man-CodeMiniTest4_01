using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingOb : MonoBehaviour
{
    private float xLimitUpper = -1f;
    private float xLimitLower = -4.5f;

    bool isDefault = true;
    bool isBack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBack == true && isDefault == false )
        {
            if (transform.position.x <= xLimitUpper)
            {
                transform.Translate(Vector3.down * Random.Range(3f, 10f) * Time.deltaTime);
            }
            else
            {
                isBack = false;
                isDefault = true;
            }
        }

        if (isDefault == true && isBack == false)
        {
            if (transform.position.x >= xLimitLower)
            {
                transform.Translate(Vector3.up * Random.Range(3f,7f) * Time.deltaTime);
            }
            else
            {
                isBack = true;
                isDefault = false;
            }

        }
    }
}
