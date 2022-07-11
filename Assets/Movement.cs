using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float speed = 50.0f;
        Vector3 moveDirection = new Vector3(xDirection, 0, vertical);
        transform.position += speed * Time.deltaTime * moveDirection;

    }
}
