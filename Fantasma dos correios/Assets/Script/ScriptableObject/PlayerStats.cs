using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int Letters;
    public float Time;
    public bool HasDog;
    public float Points;
    public float PlayerVelocity;
    public int LeftBeforeHaveGhost;
    public bool pause;
}