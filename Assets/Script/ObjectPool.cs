using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>(); // 각 Pools을 Key(string)와 List<Gameobject>로 관리하는 Dictionary
    public Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>(); // 걱 object pools에서 생성 할 prefabs을 Key(string)와 GameObject로 관라하는 Dictionary
    public int poolSize = 300; //각 pool에서 생성 할 object의 개수 = 300개
 
    void Start() //script가 시작되는 호출
    {
        foreach (var key in prefabs.Keys) //등록된 모든 prefabs에 대한 object pools을 호출
        {
            CreatePool(key, prefabs[key]); // 각 prefabs을 사용해 pools을 생성
        }
    }

    public void CreatePool(string key, GameObject prefab) //object pools을 생성하는 method, key와 prefab을 인자로 받음
    {
        if (!pools.ContainsKey(key)) //해당 key가 이미 존재하지 않으면 pools을 생성
        {
            pools[key] = new List<GameObject>(); // 새 List룰 생성하여 pools을 초기화
            for (int i = 0; i < poolSize; i++) // poolsize만큼 prefab을 복제하여 pools에 추가
            {
                GameObject obj = Instantiate(prefab); // prefab을 복제하여 새로운 GameObject 추가
                obj.SetActive(false); //생성된 obj를 pools에 추가하기 전에 false
                pools[key].Add(obj); // false된 obj를 pools에 추가
            }
        }
    }

        public GameObject Get(string key) //pools에서 false된 obj를 반환하는 method
    {
        if (pools.ContainsKey(key)) //해당 key에 대한 pools이 존재하는지 확인
        {
            foreach (var obj in pools[key]) //pools 내의 모든 obj를 순회
            {
                if (!obj.activeInHierarchy) //만약 false 된 obj가 있으면
                {
                    obj.SetActive(true); //obj를 active
                    return obj; //후 obj 반환
                }
            }
        }
        return null; //false obj가 없으면 null반환
    }

    public void Release(string key, GameObject obj) //active 된 obj를 다시 false하여 pools에 Release하는 method
    {
        if (pools.ContainsKey(key)) //해당 key에 대한 pools이 존재하는지 확인
        {
            obj.SetActive(false); //obj를 false하여 다시 pools로 반환
        }
    }
}
