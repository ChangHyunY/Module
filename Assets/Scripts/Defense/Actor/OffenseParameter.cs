using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OffenseType
{
    Skill,
    Monster,
}

public struct OffenseParameter<T>
{
    public T component;
    public OffenseType offenseType;
    public System.Action hitCallback;
    public System.Action returnCallback;

    public OffenseParameter(T _component, OffenseType _offenseType, System.Action _hitCallback = null, System.Action _returnCallback = null)
    {
        this.component = _component;
        this.offenseType = _offenseType;
        this.hitCallback = _hitCallback;
        this.returnCallback = _returnCallback;
    }
}