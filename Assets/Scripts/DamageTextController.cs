﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
       
    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
    
}
