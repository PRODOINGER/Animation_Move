using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();

                if (instance == null)
                {
                    GameObject newGameObject = new GameObject("QuestManager");
                    instance = newGameObject.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �ٸ� �������� ����
        }
        else if (instance != this)
        {
            Destroy(gameObject); // ���� �ν��Ͻ��� ������ ���ο� �ν��Ͻ��� �ı�
        }
    }
}
