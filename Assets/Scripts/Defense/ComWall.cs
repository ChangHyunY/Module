using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComWall : MonoBehaviour, IAttackable
{
    public void Hit<T>(OffenseParameter<T> offenseParameter, float damage)
    {
        offenseParameter.returnCallback?.Invoke();
    }
}
