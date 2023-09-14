using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletun : MonoBehaviour
{
    public static Singletun Instance { get; private set; }      //�ν��Ͻ��� ������ ����

    private void Awake()
    {
        if (Instance == null)           //Instance �� null�� ��
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);          //���� ������Ʈ�� scene�� ��ȯ�ǰ� �ı����� ����
        }
        else
        {
            Destroy(gameObject);                //1���� ������Ű�� ���� ������ ��ü�� �ı��Ѵ�.
        }
    }
    public int playerScore = 0;                     //���� �� �÷��̾� ���ھ�

    public void InscreaseScore(int amount)          // �Լ��� ���ؼ� ���ھ ���� ��Ų��.
    {
        playerScore += amount;
    }
}
