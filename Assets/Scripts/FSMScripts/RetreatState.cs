using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    private SmartTank smartTank;

    bool isLocated = false;

    public RetreatState(SmartTank smartTank)
    {
        this.smartTank = smartTank;
    }

    public override Type StateEnter()
    {
        return null; 
    }

    public override Type StateExit()
    {
        return null; 
    }

    public override Type StateUpdate()
    {
        Debug.Log("RetreatState");

        float time = 10;

        time -= Time.deltaTime;
        if (time < 10 && !isLocated)
        {
            smartTank.MoveToRandomPoint(1f);
            isLocated = true;
        }

        else if (time <= 0 && isLocated)
        {
            time = 10;
            isLocated = false;

            smartTank.GenPoint();
        }

        else if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) >= 30f)
        {
            return typeof(SearchState);
        }

            return null;
        
    }
}
