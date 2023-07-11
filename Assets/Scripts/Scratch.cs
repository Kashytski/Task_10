using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : MonoBehaviour
{
    [SerializeField] GameObject mask;
    private Vector3 position;
    private Vector3 oldPosition;
    private Vector3 step;
    private bool pressed = false;

    void Update()
    {
        pressed = GameManager.instance.Pressed;

        if (pressed)
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            if (oldPosition == Vector3.zero)
                oldPosition = position;
            step = (position - oldPosition) / 10;

            for (int i = 1; i < 10; i++)
            {
                GameObject obj = Instantiate(mask, oldPosition + (i + 1) * step, Quaternion.identity);
                obj.transform.parent = transform;
            }

            oldPosition = position;
        }
        else
            oldPosition = Vector3.zero;
    }

}
