using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class called AttackState which inherits from BaseState
public class AttackState : BaseState
{
    // smartTank of type SmartTank class
    private SmartTank smartTank;

    // Public AttackState which takes in smartTank as a parameter
    public AttackState(SmartTank smartTank)
    {
        this.smartTank = smartTank;
    }

    // Type of StateEnter & StateExit which returns a null value
    public override Type StateEnter()
    {
        return null;
    }

    public override Type StateExit()
    {
        return null;
    }

    // Type called StateUpdate
    public override Type StateUpdate()
    {
        // Output to Console
        Debug.Log("AttackState");

        // Declare a Float called currentHealth, assigned to returnHealth Function return value
        float currentHealth = smartTank.returnHealth();

        // If currentHealth is less than 50, then do the code below
        if (currentHealth < 50)
        {
            // Output to Console
            Debug.Log("Smart Tank Health below 50");

            // Switch to the Retreat State
            return typeof(RetreatState);
        }

        // Else if the Distance between Smart Tank and Enemy Tank is less than 30, then do the code below
        else if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) < 30f)
        {
            // Output to Console
            Debug.Log("Fire at Enemy Tank");

            // Call the TankFire Function and pass in the Enemy Tank Position in the world
            smartTank.TankFire(smartTank.enemyTank);
        }

        // Else if the Distance between Smart Tank and the Base Position is less than 30, then do the code below
        else if (Vector3.Distance(smartTank.transform.position, smartTank.basePos1.transform.position) < 30f)
        {
            // Output to Console
            Debug.Log("Base Attack");

            // Call the TankFire Function and pass in the Base Position in the world
            smartTank.TankFire(smartTank.basePos1);

            // Destroy the GameObject that has been passed in as a parameter
            GameObject.Destroy(smartTank.basePos1);
        }

        // Else
        else
        {
            // Move the Smart Tank to the Base Position, at a speed of 1
            smartTank.TanktoPath(smartTank.basePos1, 1f);
        }

        // Return null value
        return null;
    }
}
