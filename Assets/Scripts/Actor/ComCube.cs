using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Witch
{
    public class ComCube : MonoBehaviour
    {
        [SerializeField] Transform m_DamageTextPivot;

        public Vector3 GetDamageTextPivoePosition => m_DamageTextPivot.position;
    }
}