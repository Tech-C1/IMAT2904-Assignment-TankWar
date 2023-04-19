using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class called BaseState
public abstract class BaseState
{
    // Public abstract Types called StateUpdate, StateEnter and StateExit
    public abstract Type StateUpdate();
    public abstract Type StateEnter();
    public abstract Type StateExit();
}
