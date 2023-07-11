using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushController : MonoBehaviour
{
    private SpriteMask[] maskStack;
    private bool pressed = false;

    void Update()
    {
        pressed = GameManager.instance.Pressed;

        maskStack = GetComponentsInChildren<SpriteMask>();

        if (maskStack.Length > 0)
            for (int i = 0; i < maskStack.Length; i++)
                for (int j = i + 1; j < maskStack.Length; j++)
                {
                    if (Vector3.Distance(maskStack[i].transform.position, maskStack[j].transform.position) < 0.1f)
                        Destroy(maskStack[j].gameObject);
                }

        if (!pressed)
            if (maskStack.Length > 0)
                for (int i = 0; i < maskStack.Length; i++)
                    Destroy(maskStack[i].gameObject);
    }
}
