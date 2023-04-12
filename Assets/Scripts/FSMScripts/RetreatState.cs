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
        // Output to Console
        Debug.Log("RetreatState");

        // Float variable called time, set to 10
        float time = 10;

        // The time variable goes down in line with the seconds of deltaTime
        time -= Time.deltaTime;

        // If time is less than 10 and the isLocated Boolean is false then do the code below
        if (time < 10 && !isLocated)
        {
            // Move Smart Tank to a random point, with a speed of 1
            smartTank.MoveToRandomPoint(1f);

            // isLocated Boolean set to true
            isLocated = true;
        }

        // Else if time is less than or equal to 0 and the Boolean is set to true then do the code below
        else if (time <= 0 && isLocated)
        {
            // Time is set to 10
            time = 10;

            // isLocated set to false
            isLocated = false;

            // Call GenPoint Function
            smartTank.GenPoint();
        }

        // Else if the Distance between Smart Tank and Enemy Tank is more than 30, then do the code below
        else if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) >= 30f)
        {
            // Switch to the Search State
            return typeof(SearchState);
        }

        // Return null value
        return null;
        
    }
}
