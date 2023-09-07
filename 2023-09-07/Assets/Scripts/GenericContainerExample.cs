using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericContainerExample : MonoBehaviour
{
    private GenericContainer<int> intContainer;
    private GenericContainer<string> stringContainer;   //�����̳� ����
    // Start is called before the first frame update
    void Start()
    {
        intContainer = new GenericContainer<int>(10);       //10ĭ���� ����
        stringContainer = new GenericContainer<string>(5);      //5ĭ���� ����

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))       //Ű���� 1�� ������
        {
            intContainer.Add(Random.Range(0, 100));     //0~100 �������ڸ� �����̳ʿ� �ִ´�
            DisplayContainerItems(intContainer);        //�Լ��� ���ؼ� debug.log�� �����ش�
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))       //Ű���� 1�� ������
        {
            string randomString = "Item " + Random.Range(0, 100);       //������ ���ڿ��� ����� �ش�.
            stringContainer.Add(randomString);     //0~100 �������ڸ� �����̳ʿ� �ִ´�
            DisplayContainerItems(stringContainer);        //�Լ��� ���ؼ� debug.log�� �����ش�
        }

    }

    //�����̳ʿ� ��� ������ �����ִ� �Լ�
    private void DisplayContainerItems<T>(GenericContainer<T> container)
    {
        T[] item = container.GetItems();     //������ ����Ʈ�� �޾ƿ´�
        string temp = "";                   //Debug.log�� ������ ĭ string 
        for(int i =0; i<item.Length; i++)           //�����̳��� ��� ���� for ������ ���鼭
        {
            if (item[i] != null)                //���� null �� �ƴҰ��
            {
                temp += item[i].ToString() + "/";       //string �������� �����ش�.
            }
            else
            {
                temp += "Empty / ";     //null�� ��쿡�� Empty ǥ�����ش�.
            }
        }
        Debug.Log(temp);
    }
}
