using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Retreat State which inherits from BaseState
public class RetreatState : BaseState
{
    // smartTank of type SmartTank class
    private SmartTank smartTank;

    // Boolean isLocated set to true
    bool isLocated = false;

    // Public RetreatState which takes in smartTank as a parameter
    public RetreatState(SmartTank smartTank)
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
        // Declare a Float called currentHealth, assigned to returnHealth Function return value
        float currentHealth = smartTank.returnHealth();

        // Output to Console
        Debug.Log("RetreatState");

        // Float variable called time, set to 10
        float time = 10;

        // The time variable goes down in line with the seconds of deltaTime
        time -= Time.deltaTime;

        // Move Smart Tank to a random point, with a speed of 1
        smartTank.MoveToRandomPoint(1f);

        // The time variable goes up in line with the seconds of deltaTime
        time += Time.deltaTime;

        // If time is more than 10
        if (time > 10)
        {
            // Call GenPoint Function
            smartTank.GenPoint();

            // Time is set to 0
            time = 0;
        }

        // Else if the Distance between Smart Tank and Enemy Tank is more than 30, then do the code below
        else if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) >= 30f)
        {
            // Output to Console
            Debug.Log("SearchState");

            // Switch to the Search State
            return typeof(SearchState);
        }
        // Return null value
        return null;
        
    }
}
