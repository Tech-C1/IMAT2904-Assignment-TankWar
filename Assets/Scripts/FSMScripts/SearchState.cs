using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Class called SearchState which inherits from BaseState
public class SearchState : BaseState
{

    // smartTank of type SmartTank class
    private SmartTank smartTank;

    // Boolean isLocated set to true
    bool isLocated = true;

    // Float called time equals 15
    float time = 15;

    // Public SearchState which takes in smartTank as a parameter
    public SearchState(SmartTank smartTank)
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
        // If the Enemy Tank is less than 30 from Smart Tank then do the code below
        if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) < 30f)
        {
            // Float Variable called distance assigned to the Vector 3 of the 2 Tank Positions distance
            float distance = Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position);

            // Output to Console
            Debug.Log("Distance: " + distance);
            Debug.Log("Attack Transition");

            // Switch to the Attack State
            return typeof(AttackState);
        }

        // Else if Smart Tank distance between it and The Base Positions is less than 30, then do the code below
        else if (Vector3.Distance(smartTank.transform.position, smartTank.basePos1.transform.position) < 30f)
        {
            // Output to Console
            Debug.Log("Attack Transition");

            // Switch to the Attack State
            return typeof(AttackState);
        }

        // Else
        else
        {
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

            // Return null value
            return null; 
        }
    }
}