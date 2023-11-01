namespace Anchor.Core.Pool
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Pool<T> : IDisposable
    {
        private List<T> m_InactiveObjects;
        private List<T> m_ActiveObjects;

        private int m_MaxPoolSize;
        private int m_ActiveCount = 0;

        public Pool(T component, int initalGenerateCount, int initalCapacity, int maxPoolSize = 0)
        {
            m_MaxPoolSize = maxPoolSize;

            if (m_MaxPoolSize > 0)
            {
                if (initalGenerateCount > m_MaxPoolSize)
                {
                    initalGenerateCount = m_MaxPoolSize;
                }

                if (initalCapacity > m_MaxPoolSize)
                {
                    initalCapacity = m_MaxPoolSize;
                }
                else if (initalCapacity < initalGenerateCount)
                {
                    initalCapacity = initalGenerateCount;
                }
            }

            m_InactiveObjects = new List<T>(initalCapacity);
            m_ActiveObjects = new List<T>(initalCapacity);

            m_InactiveObjects.Add(component);
        }

        ~Pool()
        {
            Clear();
        }

        public void Add(T component)
        {
            if(m_MaxPoolSize <= m_InactiveObjects.Count + m_ActiveObjects.Count)
            {
                throw new Exception("pool is fulled");
            }
            else
            {
                m_InactiveObjects.Add(component);
            }
        }

        public T Get()
        {
            T item = default(T);

            if(m_InactiveObjects.Count > 0)
            {
                int idx = m_InactiveObjects.Count - 1;
                item = m_InactiveObjects[idx];
                m_InactiveObjects.RemoveAt(idx);
            }
            else
            {
                if(m_MaxPoolSize <= m_InactiveObjects.Count + m_ActiveObjects.Count)
                {
                    throw new Exception("pool is fulled");
                }
            }

            m_ActiveObjects.Add(item);
            m_ActiveCount++;

            return item;
        }

        public void Return(T item)
        {
            if(!m_ActiveObjects.Contains(item))
            {
                throw new Exception("not found item in active object queue");
            }

            if(m_InactiveObjects.Contains(item))
            {
                throw new Exception("found item in inactive object list");
            }

            m_ActiveObjects.Remove(item);
            m_ActiveCount--;

            m_InactiveObjects.Add(item);
        }

        public void ReturnAll()
        {
            for(int i = 0, loop = m_ActiveObjects.Count; i < loop; ++i)
            {
                Return(m_ActiveObjects[i]);
            }
        }

        public void Clear()
        {
            foreach(var item in m_ActiveObjects)
            {
                m_InactiveObjects.Add(item);
            }

            m_ActiveObjects.Clear();
            m_ActiveCount = 0;
        }

        public void Dispose()
        {
            Clear();
        }
    }
}