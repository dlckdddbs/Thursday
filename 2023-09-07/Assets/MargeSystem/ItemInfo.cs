using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int slotId;      //���� ��ȣ
    public int itemId;      //������ ��ȣ 

    public void InitDummy(int slotId, int itemId)
    {
        this.slotId = slotId;
        this.itemId = itemId;
    }
}
