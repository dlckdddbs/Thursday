using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    // Start is called before the first frame update
    public enum SLOTSTATE
    {
        EMPTY,
        FULL
    }

    public int id;
    public Item itemObject;         //������ ������ ���� (Ŀ���� Class)
    public SLOTSTATE state = SLOTSTATE.EMPTY;       //���°� ������ �� ���� �� EMPTY �Է�

    private void ChangeStateTo(SLOTSTATE targetState)       //�ش� ������ ���°��� ��ȯ �����ִ� �Լ�
    {
        state = targetState;
    }

    public void ItemGrabbed()           //������ RayCast�� ���ؼ� �������� ����� �� 
    {
        Destroy(itemObject.gameObject);         //�������� �������� ����
        ChangeStateTo(SLOTSTATE.EMPTY);         //������ �� ����(State)
    }


    public void CreateItem(int id)
    {
        string itemPath = "Prefabs/item_" + id.ToString("000");         //,������ ������ ���(Resources/Prefabs/Item_000)���� ����
        var itemG0 = (GameObject)Instantiate(Resources.Load(itemPath)); //������ ��ο� �մ� �������� ���� 
        //������ ���� ������Ʈ �ʱ�ȭ
        itemG0.transform.SetParent(this.transform);     //Slot ������Ʈ ������ ����
        itemG0.transform.localPosition = Vector3.zero;      //���� ��ġ�� Vector(0,0,0)
        itemG0.transform.localScale = Vector3.one;          //���� Scale �� Vector(1,1,1);
        //���� Item ������Ʈ ������ �Է�
        itemObject = itemG0.GetComponent<Item>();           //������ ���� ������Ʈ�� Item class�� ����
        itemObject.Init(id, this);

        ChangeStateTo(SLOTSTATE.FULL);          //�����ؼ� ������ ������ ���ִ�.

    }
}
