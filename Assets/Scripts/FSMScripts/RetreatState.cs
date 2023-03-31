using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    private SmartTank smartTank;

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
        return null; 
    }
}
