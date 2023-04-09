using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private SmartTank smartTank;

    public AttackState(SmartTank smartTank)
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
        Debug.Log("AttackState");

        float currentHealth = smartTank.returnHealth();

        if (currentHealth < 50)
        {
            Debug.Log("Smart Tank Health below 50");

            return typeof(RetreatState);
        }

        else if (Vector3.Distance(smartTank.transform.position, smartTank.enemyTank.transform.position) < 30f)
        {
            Debug.Log("Fire at Enemy Tank");

            smartTank.TankFire(smartTank.enemyTank);
        }

        else if (Vector3.Distance(smartTank.transform.position, smartTank.basePos1.transform.position) < 30f)
        {
            Debug.Log("Base Attack");

            smartTank.TankFire(smartTank.basePos1);
            GameObject.Destroy(smartTank.basePos1);
        }

        else
        {
            smartTank.TanktoPath(smartTank.basePos1, 1f);
        }


        return null;
    }
}
