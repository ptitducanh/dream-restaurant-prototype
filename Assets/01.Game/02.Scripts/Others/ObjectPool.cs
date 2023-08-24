using System.Collections.Generic;
using Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Others
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        [SerializeField] Dictionary<string, GameObject> poolPrefab = new Dictionary<string, GameObject>();
        
        [SerializeField] [ReadOnly] private Dictionary<string, List<GameObject>> _pool = new Dictionary<string, List<GameObject>>();
        
        
        public GameObject Get(string name)
        {
            if (!_pool.ContainsKey(name))
            {
                _pool.Add(name, new List<GameObject>());
            }

            if (_pool[name].Count == 0)
            {
                var prefab = poolPrefab[name];
                var go = Instantiate(prefab);
                go.name = name;
                go.SetActive(true);
                return go;
            }

            var last = _pool[name].Count - 1;
            var result = _pool[name][last];
            _pool[name].RemoveAt(last);
            result.SetActive(true);
            return result;
        }
        
        public void Return(GameObject go)
        {
            if (!_pool.ContainsKey(go.name))
            {
                _pool.Add(go.name, new List<GameObject>());
            }

            _pool[go.name].Add(go);
            go.SetActive(false);
        }

        private void InitializePool()
        {
            foreach (var prefab in poolPrefab)
            {
                var itemObject = Instantiate(prefab.Value);
                itemObject.name = prefab.Key;
                
                Return(itemObject);
            }
        }
    }
}