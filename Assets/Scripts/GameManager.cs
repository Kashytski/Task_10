using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject scratchFinal;
    private bool[] area = new bool[15];
    private bool pressed = false;
    private bool complete = true;
    public bool Pressed => pressed;
    public bool Complete => complete;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        AreaCheck.OnAddArea += AddArea;
    }

    void OnDestroy()
    {
        AreaCheck.OnAddArea -= AddArea;
    }

    private void AddArea(int num)
    {
        if (num > -1 && num < area.Length)
            area[num] = true;
        else
            complete = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            pressed = true;
        else if (Input.GetMouseButtonUp(0))
        {
            pressed = false;

            for (int i = 0; i < area.Length; i++)
            {
                if (!area[i])
                    complete = false;
                else
                    area[i] = false;
            }

            if (complete)
            {
                scratchFinal.SetActive(true);
                StartCoroutine(RestartGame());
            }
            complete = true;
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(5f);
        scratchFinal.SetActive(false);
    }
}
