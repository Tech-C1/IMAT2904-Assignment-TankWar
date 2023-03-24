using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> states;

    public BaseState currentState;
    public BaseState CurrentState
    {
        get
        {
            return currentState; 
        }

        private set
        {
            currentState = value; 
        }
    }

}
