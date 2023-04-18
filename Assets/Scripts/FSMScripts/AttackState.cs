using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        // Get the Dictionary of Bases found by the SmartTank
        Dictionary<GameObject, float> basesFound = smartTank.GetBasesFound();

        // Output to Console
        Debug.Log("AttackState");

        // Declare a Float called currentHealth, assigned to returnHealth Function return value
        float currentHealth = smartTank.returnHealth();

        // If currentHealth is less than 30, then do the code below
        if (currentHealth < 30)
        {
            // Output to Console
            Debug.Log("Smart Tank Health below 30");

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

        else if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) > 30f)
        {
            // Output to Console
            Debug.Log("Attack to Search State"); 

            // Switch to the Search State
            return typeof(SearchState);
        }


        // Return null value
        return null;
    }
}
