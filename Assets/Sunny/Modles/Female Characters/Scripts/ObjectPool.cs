using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectPool : MonoBehaviour
{
    private GameObject poolParent;
    /// <summary>
    /// Object Pool
    /// </summary>
    Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();
    /// <summary>
    /// Prefab
    /// </summary>
    Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> parents = new Dictionary<string, GameObject>();

    List<GameObject> tempList;
    GameObject tempGo;

    public static ObjectPool _Instance;
    public static ObjectPool Instance
    {
        get
        {
            return _Instance;
        }
    }

    public bool Contains(string prefabName)
    {
        if (string.IsNullOrEmpty(prefabName))
            return false;
        bool result= pool.ContainsKey(prefabName);
            return result;
    }

    public void ClaarAll()
    {
        foreach (var item in pool)
        {
            foreach (Object go in item.Value)
            {
                DestroyImmediate(go, true);
            }
        }
        pool.Clear();

        prefabs.Clear();

        foreach (var item in parents)
        {
            DestroyImmediate(item.Value, true);
        }
        parents.Clear();
    }



    protected void Awake()
    {
        _Instance = this as ObjectPool;
        poolParent = new GameObject("ObjectPool");
        DontDestroyOnLoad(poolParent);
    }

    public void InitPool(GameObject prefab, int count =5)
    {
        if (prefab == null)
            return;

        if (prefabs.ContainsKey(prefab.name))
            return;
        else
        {
            prefabs.Add(prefab.name, prefab);
            var gobj = poolParent.transform.Find(prefab.name);
            Transform parent=null;
            if (gobj)
                parent = gobj.transform;
            if (!parent)
                parent = new GameObject(prefab.name).transform;
            parent.SetParent(poolParent.transform);
            parent.name = prefab.name;
            parents.Add(prefab.name, parent.gameObject);
            pool.Add(prefab.name, new List<GameObject>());
            for (int i = 0; i < count; i++)
            {
                tempGo = Instantiate(prefab, parent);
                tempGo.name = prefab.name;
                pool[prefab.name].Add(tempGo);
                tempGo.SetActive(false);
            }
        }
    }

    /// <summary>
    /// destroyPool
    /// </summary>
    /// <param name="key"></param>
    public void DestroyPool(string key)
    {
        if (!Application.isPlaying) return;
        var objs = pool[key];
        prefabs.Remove(key);
        parents.Remove(key);
        pool.Remove(key);
        foreach (var item in objs)
            GameObject.Destroy(item);
        CleanMemory();
    }


    //CleanMemory
    public static void CleanMemory()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }




    /// <summary>
    /// GetPoolObject
    /// </summary>
    /// <param name="objName"></param>
    /// <returns></returns>
    public GameObject GetObj(string objName, Transform parent = null)
    {
        tempGo = null;
        if (pool.TryGetValue(objName, out tempList))
        {
            if (tempList.Count > 0)
            {
                tempGo = tempList[0];
                tempList.RemoveAt(0);
                tempGo.transform.SetParent(parent);
                
            }
            else
            {
                GameObject go = null;
                if (parent)
                    tempGo = Instantiate(prefabs[objName], parent);
                else
                    tempGo = Instantiate(prefabs[objName]);
                    tempGo.name = objName;
                
            }
        }
        return tempGo;
       
    }
    /// <summary>
    /// RecycleObj
    /// </summary>
    /// <param name="objName"></param>
    public void RecycleObj(GameObject obj)
    {
        if (!Application.isPlaying) return;
        if (obj)
            if (pool.ContainsKey(obj.name))
            {
                try
                {
                    if (pool[obj.name] == null)
                    {
                        Destroy(obj);
                        return;
                    }
                    else  if (pool.Count > 144 )
                    {
                        Debug.LogError(pool.Count);
                        Destroy(obj);
                        return;
                    }
                    else
                    {
                        pool[obj.name].Add(obj);
                        obj.SetActive(false);
                        obj.transform.SetParent(parents[obj.name].transform);
                        return;
                    }
                }
                catch (System.Exception)
                {
                    
                }
            }
    }


}
