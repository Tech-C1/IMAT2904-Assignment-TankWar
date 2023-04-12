using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Smart Tank class which inherits from AI Tank
public class SmartTank : AITank
{
    // Type StateMachine called stateMachine
    private StateMachine stateMachine;

    // Gameobject called enemyTank
    public GameObject enemyTank;

    // GameObjects for Base Positions 1 & 2
    public GameObject basePos1;
    public GameObject basePos2; 

    // Float Variable called sHealth
    float sHealth; 

    // Public Function called AITankStart
    public override void AITankStart()
    {
       
        stateMachine = GetComponent<StateMachine>();

        // Dictionary of all 3 States for Finite State Machine
        Dictionary<Type, BaseState> states = new Dictionary<Type, BaseState>();
        {
            states.Add(typeof(SearchState), new SearchState(this));
            states.Add(typeof(AttackState), new AttackState(this));
            states.Add(typeof(RetreatState), new RetreatState(this));
        };

        // stateMachine Set state to current states
        stateMachine.SetStates(states);
    }

    // AITankUpdate Function, which updates every frame
    public override void AITankUpdate()
    {

    }

    // The Functions below allow the State classes to access Protected Functions in AI Tank
    // Public Function called MoveToRandomPoint that takes in a float parameter
    public void MoveToRandomPoint(float normalizedSpeed)
    {
        // FollowPathtoRandom Point Function which takes in the parameter above
        FollowPathToRandomPoint(normalizedSpeed);
    }

    // Public Function called GenPoint 
    public void GenPoint()
    {
        // Calls Function from AI Tank
        GenerateRandomPoint();
    }

    // Public Float Function which returns a value
    public float returnHealth()
    {
        // Returns GetHealthLevel
        return GetHealthLevel;
    }

    // Public Void Function called TankFire which takes in a GameObject as a parameter
    public void TankFire(GameObject enemyLocation)
    {
        // FireAtPoint Function which takes in the parameter above
        FireAtPoint(enemyLocation);
    }

    // Public Void Function called TanktoPath which takes in a GameObject and a Float as a parameter
    public void TanktoPath(GameObject pointInWorld, float normalizedSpeed)
    {
        // FollowPathToPoint Function which takes in the parameters above
        FollowPathToPoint(pointInWorld, normalizedSpeed); 
    }

    // Public Function called AIOnCollisionEnter, which takes in of type Collision as a parameter
public override void AIOnCollisionEnter(Collision collision)
    {

    }
}
