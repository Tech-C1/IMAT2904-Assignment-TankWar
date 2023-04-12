using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Class called StateMachine 
public class StateMachine : MonoBehaviour
{
    // Private Dictionary called states
    private Dictionary<Type, BaseState> states;

    // BaseState Types called currentState & CurrentState
    public BaseState currentState;
    public BaseState CurrentState
    {
        get
        {
            // return the currentState
            return currentState;
        }
        private set
        {
            // set currentState parameter to value
            currentState = value;
        }
    }

    // Public Function called SetStates that takes in a Dictionary parameter called states
    public void SetStates(Dictionary<Type, BaseState> states)
    {
        // states equals states
        this.states = states;
    }

    // Function Function called Update
    public void Update()
    {
        // If Statements

        // if CurrentState equals null then do the code below
        if (CurrentState == null)
        {
            // CurrentState is assigned to states
            CurrentState = states.Values.First();
        }

        // Else
        else
        {
            // Declare nextStae and assign it to type StateUpdate
            var nextState = CurrentState.StateUpdate();

            // If Statement
            if (nextState != null && nextState != CurrentState.GetType())
            {
                // Switch to the Next State
                SwitchToState(nextState);
            }
        }
    }

    // Function called SwitchToState which takes in a parameter of Type 
    void SwitchToState(Type nextState)
    {
        // Current State which calls Functions in the Base State class
        CurrentState.StateExit();
        CurrentState = states[nextState];
        CurrentState.StateEnter();
    }
}
