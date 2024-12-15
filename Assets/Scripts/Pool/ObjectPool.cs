using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private readonly Queue<T> _pool = new Queue<T>();
    private readonly IAbstractFactory<T> _factory;

    public ObjectPool(IAbstractFactory<T> factory, int initialSize)
    {

        _factory = factory;

        for (int i = 0; i < initialSize; i++)
        {
            T obj = CreateNewObject();
            ReturnToPool(obj);
        }
        ServiceLocator.Instance.RegisterService(this);
    }

    public T GetFromPool()
    {
        if (_pool.Count > 0)
        {
            T obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            return CreateNewObject();
        }
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }

    public void EmptyPool()
    {
        _pool.Clear();
    }

    private T CreateNewObject()
    {
        T newObj = _factory.Create();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

}
