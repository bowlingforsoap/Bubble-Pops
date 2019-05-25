using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class GameObjectPool<T> : MonoBehaviour where T : Component
{
    public T prefab;

    public static GameObjectPool<T> Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private Queue<T> pool = new Queue<T>();

    public T Get()
    {
        if (pool.Count == 0)
        {
            AddGameObjects(1);
        }

        return pool.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        pool.Enqueue(objectToReturn);
    }

    public void AddGameObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            T newObject = Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            pool.Enqueue(newObject);

            newObject.GetComponent<IGameObjectPooled<T>>().Pool = this; // <- GetComponent is pretty expensive and should be called as rarely, as possible (https://www.youtube.com/watch?v=PBqTrK3z_KM&t=158)
        }
    }
}

public interface IGameObjectPooled<T> where T : Component
{
    GameObjectPool<T> Pool { get; set; }
}
