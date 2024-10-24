using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>(); // �� Pools�� Key(string)�� List<Gameobject>�� �����ϴ� Dictionary
    public Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>(); // �� object pools���� ���� �� prefabs�� Key(string)�� GameObject�� �����ϴ� Dictionary
    public int poolSize = 300; //�� pool���� ���� �� object�� ���� = 300��
 
    void Start() //script�� ���۵Ǵ� ȣ��
    {
        foreach (var key in prefabs.Keys) //��ϵ� ��� prefabs�� ���� object pools�� ȣ��
        {
            CreatePool(key, prefabs[key]); // �� prefabs�� ����� pools�� ����
        }
    }

    public void CreatePool(string key, GameObject prefab) //object pools�� �����ϴ� method, key�� prefab�� ���ڷ� ����
    {
        if (!pools.ContainsKey(key)) //�ش� key�� �̹� �������� ������ pools�� ����
        {
            pools[key] = new List<GameObject>(); // �� List�� �����Ͽ� pools�� �ʱ�ȭ
            for (int i = 0; i < poolSize; i++) // poolsize��ŭ prefab�� �����Ͽ� pools�� �߰�
            {
                GameObject obj = Instantiate(prefab); // prefab�� �����Ͽ� ���ο� GameObject �߰�
                obj.SetActive(false); //������ obj�� pools�� �߰��ϱ� ���� false
                pools[key].Add(obj); // false�� obj�� pools�� �߰�
            }
        }
    }

        public GameObject Get(string key) //pools���� false�� obj�� ��ȯ�ϴ� method
    {
        if (pools.ContainsKey(key)) //�ش� key�� ���� pools�� �����ϴ��� Ȯ��
        {
            foreach (var obj in pools[key]) //pools ���� ��� obj�� ��ȸ
            {
                if (!obj.activeInHierarchy) //���� false �� obj�� ������
                {
                    obj.SetActive(true); //obj�� active
                    return obj; //�� obj ��ȯ
                }
            }
        }
        return null; //false obj�� ������ null��ȯ
    }

    public void Release(string key, GameObject obj) //active �� obj�� �ٽ� false�Ͽ� pools�� Release�ϴ� method
    {
        if (pools.ContainsKey(key)) //�ش� key�� ���� pools�� �����ϴ��� Ȯ��
        {
            obj.SetActive(false); //obj�� false�Ͽ� �ٽ� pools�� ��ȯ
        }
    }
}
