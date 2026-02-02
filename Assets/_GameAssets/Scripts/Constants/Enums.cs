using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum PlayerStates
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Attacking,
        Dead
    }
    public enum MissileTypes
    {
        Normal,
        Multi,
        Nuke
    }
}
