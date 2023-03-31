using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private SmartTank smartTank;

    public SearchState(SmartTank smartTank)
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
        if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) < 30f)
        {
            float distance = Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position);
            Debug.Log("Distance: " + distance);

            Debug.Log("Attack"); 
            return typeof(AttackState);
        }
        else
        {
            return null; 
        }
    }
}