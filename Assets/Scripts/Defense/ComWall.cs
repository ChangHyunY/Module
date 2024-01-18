using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComWall : MonoBehaviour
{
    private static ComWall m_Root;

    public static ComWall Root => m_Root;

    private void Awake()
    {
        m_Root = this;
    }
}
