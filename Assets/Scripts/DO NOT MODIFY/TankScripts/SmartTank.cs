using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SmartTank : AITank
{
    private StateMachine stateMachine;

    public GameObject enemyTank;

    public GameObject basePos1;
    public GameObject basePos2; 

    float sHealth; 

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

    }

    public void MoveToRandomPoint(float normalizedSpeed)
    {
        FollowPathToRandomPoint(normalizedSpeed);
    }

    public void GenPoint()
    {
        GenerateRandomPoint();
    }

    public float returnHealth()
    {
        return GetHealthLevel;
    }

    public void TankFire(GameObject enemyLocation)
    {
        FireAtPoint(enemyLocation);
    }

    public void TanktoPath(GameObject pointInWorld, float normalizedSpeed)
    {
        FollowPathToPoint(pointInWorld, normalizedSpeed); 
    }



// Implement the AIOnCollisionEnter(Collision) method
public override void AIOnCollisionEnter(Collision collision)
    {

    }
}
