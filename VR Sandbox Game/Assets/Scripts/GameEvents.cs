﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO - the whole class
public class GameEvents : MonoBehaviour
{   

    public static GameEvents current;

    public delegate void onLoadEvent();
}