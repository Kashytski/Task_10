using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class AreaCheck : AreaWrong
{
    void Awake()
    {
        Regex rgx = new Regex("[a-z A-Z (-) ]");
        string str = gameObject.name;
        num = int.Parse(rgx.Replace(gameObject.name, ""));
    }
}
