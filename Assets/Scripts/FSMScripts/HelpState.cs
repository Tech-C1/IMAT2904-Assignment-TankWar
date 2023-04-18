using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Class called SearchState which inherits from BaseState
public class HelpState : BaseState
{

    // smartTank of type SmartTank class
    private SmartTank smartTank;

    // Boolean isLocated set to true
    bool isLocated = true;

    // Public SearchState which takes in smartTank as a parameter
    public HelpState(SmartTank smartTank)
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
        // Get the Dictionary of consumables found by the SmartTank
        Dictionary<GameObject, float> consumablesFound = smartTank.GetConsumablesFound();

        // Declare a Float called currentHealth, assigned to returnHealth Function return value
        float currentHealth = smartTank.returnHealth();

        // Float called time equals 15
        float time = 15;

        // If currentHealth is less than 30 
        if (currentHealth < 30)
        {
            // If the count of consumables found is more than 0, then do the code below
            if (smartTank.consumablesFound.Count > 0)
            {
                // Get the first consumable in the dictionary and set it as the target position
                GameObject consumablePosition = consumablesFound.First().Key;
                smartTank.SetConsumablePosition(consumablePosition);
                smartTank.TanktoPath(consumablePosition, 1f);

                time += Time.deltaTime;
                if (time > 10)
                {
                    // Call GenPoint Function
                    smartTank.GenPoint();

                    // Time is set to 0
                    time = 0;
                }

                // Output to Console
                Debug.Log("Finding consumable");
            }
            else
            {
                // Output to Console
                Debug.Log("No consumables found");
                Debug.Log("Switch to Search State");

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
            }
        }

        // Else
        else
        {
            // Return null value
            return null;
        }

        return null; 
    }
}