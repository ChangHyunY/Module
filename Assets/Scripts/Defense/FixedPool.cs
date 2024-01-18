using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPool<T> : IDisposable
{
    private Queue<T> m_InactiveObjects;
    private List<T> m_ActiveObjects;

    public FixedPool(T component)
    {
        m_InactiveObjects = new Queue<T>();
        m_ActiveObjects = new List<T>();
    }

    ~FixedPool()
    {
        Clear();
    }

    public void Add(T component)
    {
        m_InactiveObjects.Enqueue(component);
    }

    public T Get()
    {
        T item = default(T);

        if(m_InactiveObjects.Count > 0)
        {
            item = m_InactiveObjects.Dequeue();
            m_ActiveObjects.Add(item);
        }

        return item;
    }

    public void Return(T item)
    {
        if(m_ActiveObjects.Contains(item))
        {
            m_ActiveObjects.Remove(item);
        }

        m_InactiveObjects.Enqueue(item);
    }

    public void ReturnAll()
    {
        foreach(T activeObject in m_ActiveObjects)
        {
            m_InactiveObjects.Enqueue(activeObject);
        }

        m_ActiveObjects.Clear();
    }

    public void Clear()
    {
        m_InactiveObjects.Clear();
        m_ActiveObjects.Clear();
    }

    public void Dispose()
    {
        Clear();
    }
}
