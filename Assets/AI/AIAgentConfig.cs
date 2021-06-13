﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AIAgentConfig : ScriptableObject
{
    public float maxTime = 2f;
    public float maxDistance = 1.0f;
    public float maxSightDistance = 5.0f;
    public float dist;
}
