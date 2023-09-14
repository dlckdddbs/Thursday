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
    public Item itemObject;         //선언한 아이템 정의 (커스텀 Class)
    public SLOTSTATE state = SLOTSTATE.EMPTY;       //상태값 선언한 것 정의 후 EMPTY 입력

    private void ChangeStateTo(SLOTSTATE targetState)       //해당 슬롯의 상태값을 변환 시켜주는 함수
    {
        state = targetState;
    }

    public void ItemGrabbed()           //유저가 RayCast를 통해서 아이템을 잡았을 때 
    {
        Destroy(itemObject.gameObject);         //슬롯위에 아이템을 삭제
        ChangeStateTo(SLOTSTATE.EMPTY);         //슬롯은 빈 상태(State)
    }


    public void CreateItem(int id)
    {
        string itemPath = "Prefabs/item_" + id.ToString("000");         //,생성할 아이템 경로(Resources/Prefabs/Item_000)부터 생성
        var itemG0 = (GameObject)Instantiate(Resources.Load(itemPath)); //아이템 경로에 잇는 프리팹을 생성 
        //생성한 게임 오브젝트 초기화
        itemG0.transform.SetParent(this.transform);     //Slot 오브젝트 하위로 설정
        itemG0.transform.localPosition = Vector3.zero;      //로컬 위치는 Vector(0,0,0)
        itemG0.transform.localScale = Vector3.one;          //로컬 Scale 은 Vector(1,1,1);
        //생성 Item 컴포넌트 데이터 입력
        itemObject = itemG0.GetComponent<Item>();           //생성한 게임 오브젝트의 Item class를 접근
        itemObject.Init(id, this);

        ChangeStateTo(SLOTSTATE.FULL);          //생성해서 아이템 슬롯이 차있다.

    }
}
