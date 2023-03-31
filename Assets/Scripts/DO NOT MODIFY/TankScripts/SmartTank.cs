using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SmartTank : AITank
{
    private StateMachine stateMachine;
    public GameObject enemyTank;

    public override void AITankStart()
    {
        stateMachine = GetComponent<StateMachine>();

        Dictionary<Type, BaseState> states = new Dictionary<Type, BaseState>();
        {
            states.Add(typeof(SearchState), new SearchState(this));
            states.Add(typeof(AttackState), new AttackState(this));
            states.Add(typeof(RetreatState), new RetreatState(this));
        };

        stateMachine.SetStates(states);
    }

    public override void AITankUpdate()
    {

        if (GetHealthLevel < 50 || GetAmmoLevel < 5)
        {
               FollowPathToPoint(enemyTank, 1f);
        }
    }

    // Implement the AIOnCollisionEnter(Collision) method
    public override void AIOnCollisionEnter(Collision collision)
    {

    }
}
