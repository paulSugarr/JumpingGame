﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidOnClick : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy(gameObject);
        }
    }
}
