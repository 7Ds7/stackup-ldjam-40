﻿using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
    public void NextLevelButton(int index)
    {
        Application.LoadLevel(index);
    }

    public void NextLevelButton(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}