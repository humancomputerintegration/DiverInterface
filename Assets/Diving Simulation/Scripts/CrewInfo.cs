using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Minimal struct containing basic information to pass about a crewmate.
 */
public struct CrewInfo
{
    public string name;
    public Vector3 worldLocation;
    public int frequency;

    public CrewInfo(string n, Vector3 w, int f)
    {
        this.name = n;
        this.worldLocation = w;
        this.frequency = f;
    }
}