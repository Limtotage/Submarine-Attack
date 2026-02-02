using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance;
    private Enums.PlayerStates currentState;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentState = Enums.PlayerStates.Idle;
    }
    public void SetState(Enums.PlayerStates newState)
    {
        if(currentState==newState) return;
        currentState = newState;
        Debug.Log("Player state changed to: " + currentState.ToString());
    }
    public Enums.PlayerStates GetCurrentState()
    {
        return currentState;
    }
}
