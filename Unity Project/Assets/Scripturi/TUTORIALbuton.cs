﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TUTORIALbuton : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(2);
        }
    }
}
