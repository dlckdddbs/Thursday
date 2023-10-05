using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SLOTSTATE               //���� ���°�
    {
        EMPTY,
        FULL
    }
    public int id;
    public Item itemObject;                     //������ ������ ���� (Ŀ���� Class)
    public SLOTSTATE state = SLOTSTATE.EMPTY;   //���°� �����Ѱ� ������ EMPTY �Է�

    private void ChangeStateTo(SLOTSTATE targetState)   //�ش� ������ ���°��� ��ȯ �����ִ� �Լ�
    {
        state = targetState;
    }
    public void ItemGrabbed()                           //������ RayCast�� ���ؼ� �������� �������
    {
        Destroy(itemObject.gameObject);                 //�������� �������� ����
        ChangeStateTo(SLOTSTATE.EMPTY);                 //������ �� ����(State)
    }
    public void CreateItem(int id)
    {
        string itemPath = "Prefabs/Item_" + id.ToString("000"); //������ ������ ��� (Resources/Prefabs/Item_000)���� ����
        var itemGO = (GameObject)Instantiate(Resources.Load(itemPath)); //������ ��ο� �ִ� �������� ����
        //������ ���� ������Ʈ �ʱ�ȭ 
        itemGO.transform.SetParent(this.transform);         //Slot ������Ʈ ������ ����
        itemGO.transform.localPosition = Vector3.zero;      //���� ��ġ�� Vecter3(0,0,0)
        itemGO.transform.localScale = Vector3.one;          //���� Scale�� Vecter3(1,1,1)
        //���� Item ������Ʈ ������ �Է�
        itemObject = itemGO.GetComponent<Item>();           //������ ���� ������Ʈ�� Item Class�� ����
        itemObject.Init(id, this);                          //�Լ��� ���� �� �Է�

        ChangeStateTo(SLOTSTATE.FULL);                      //�����ؼ� ������ ������ ���ִ�.
    }
}