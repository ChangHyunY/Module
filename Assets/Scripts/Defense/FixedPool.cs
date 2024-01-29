using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPool<T> : IDisposable
{
    private Queue<T> m_InactiveObjects;
    private List<T> m_ActiveObjects;

    private int m_InactiveObjectCount;
    private int m_ActiveObjectCount;

    public int InactiveObjectCount => m_InactiveObjectCount;
    public int ActiveObjectCount => m_ActiveObjectCount;

    public FixedPool(T component)
    {
        m_InactiveObjects = new Queue<T>();
        m_ActiveObjects = new List<T>();

        m_InactiveObjectCount = 0;
        m_ActiveObjectCount = 0;
    }

    ~FixedPool()
    {
        Clear();
    }

    public void Add(T component)
    {
        m_InactiveObjects.Enqueue(component);
        ++m_InactiveObjectCount;
    }

    public T Get()
    {
        T item = default(T);

        if(m_InactiveObjects.Count > 0)
        {
            item = m_InactiveObjects.Dequeue();
            m_ActiveObjects.Add(item);

            --m_InactiveObjectCount;
            ++m_ActiveObjectCount;
        }

        return item;
    }

    public void Return(T item)
    {
        if(m_ActiveObjects.Contains(item))
        {
            m_ActiveObjects.Remove(item);
            --m_ActiveObjectCount;
        }

        m_InactiveObjects.Enqueue(item);
        ++m_InactiveObjectCount;
    }

    public void ReturnAll()
    {
        foreach(T activeObject in m_ActiveObjects)
        {
            m_InactiveObjects.Enqueue(activeObject);
            ++m_InactiveObjectCount;
        }

        m_ActiveObjects.Clear();
        m_ActiveObjectCount = 0;
    }

    public void Clear()
    {
        m_InactiveObjects.Clear();
        m_ActiveObjects.Clear();

        m_InactiveObjectCount = 0;
        m_ActiveObjectCount = 0;
    }

    public void Dispose()
    {
        Clear();
    }
}
