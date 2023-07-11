using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private Vector3 step = new Vector3(0, 0.001f, 0);
    private bool tik_tak = true;

    void Update()
    {
        if (tik_tak)
        {
            transform.position += step;
            tik_tak = false;
        }
        else
        {
            transform.position -= step;
            tik_tak = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "brush")
            Destroy(other.gameObject);
    }
}
