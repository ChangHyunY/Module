using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void Hit<T>(OffenseParameter<T> offenseParameter, float damage);
}
