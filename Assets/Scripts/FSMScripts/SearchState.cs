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
        // Get the Dictionary of consumables found by the SmartTank
        Dictionary<GameObject, float> consumablesFound = smartTank.GetConsumablesFound();

        // Get the Dictionary of consumables found by the SmartTank
        Dictionary<GameObject, float> basesFound = smartTank.GetBasesFound();

        // Declare a Float called currentFuel, assigned to returnFuel Function return value
        float currentFuel = smartTank.returnFuel();

        // Declare a Float called currentHealth, assigned to returnHealth Function return value
        float currentHealth = smartTank.returnHealth();

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

        // Else if the count of consumables found is more than 0, then do the code below
        else if (smartTank.consumablesFound.Count > 0)
        {
            // Get the first consumable in the dictionary and set it as the target position
            GameObject consumablePosition = consumablesFound.First().Key;
            smartTank.SetConsumablePosition(consumablePosition);
            smartTank.TanktoPath(consumablePosition, 1f);

            // Output to Console
            Debug.Log("Finding consumable");

            // Return null value
            return null; 
        }

        // Else if the count of Bases found is more than 0, then do the code below
        else if (basesFound.Count > 0 && basesFound.First().Key != null)
        {
            // Output to Console
            Debug.Log("Base Detected"); 

            GameObject basePosition = basesFound.First().Key;

            // if basePosition does not equal to null
            if (basePosition != null)
            {
               // If the distance between the Smart Tank and the Bases' Position is less than 40, then do the code below
                if (Vector3.Distance(smartTank.transform.position, basePosition.transform.position) < 40f)
                {
                    // Output to Console
                    Debug.Log("Base Attack!");

                    // Fire at the position of the Base
                    smartTank.TankFire(basePosition);
                }

                // Else
                else
                {
                    // Go to the Bases' Position, with the Speed of 1
                    smartTank.TanktoPath(basePosition, 1f);
                }
            }

            // Return null value
            return null;
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
