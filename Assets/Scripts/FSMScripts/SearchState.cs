using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchState : BaseState
{
    private SmartTank smartTank;

    bool isLocated = true;
    float time = 15;

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

            Debug.Log("Attack Transition"); 
            return typeof(AttackState);
        }
        else
        {
            smartTank.MoveToRandomPoint(1f);

            time += Time.deltaTime;

            if (time > 10)
            {
                smartTank.GenPoint();
                time = 0;

            }

            return null; 
        }
    }
}