using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horiz;
    float vert;
    Vector3 dir;
    [Range(1.0f, 10.0f)]
    public float dampening;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        dir = new Vector3(horiz, 0.0f, vert);

        transform.position += dir / dampening;
    }
}
