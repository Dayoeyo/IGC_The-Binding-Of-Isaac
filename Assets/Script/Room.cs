using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    /* roomNumber
     * 1 : 일반방
     * 2 : 시작방
     * 3 : 보스방
     * 4 : 상점방
     * 5 : 황금방
     * 6 : 달방
     * roomNumber 변수의 수치에 맞춰서 방 오브젝트 배치.
     */

    private int roomNumber; // 방 종류 번호
    public int RoomNumber
    { get { return roomNumber; } }
    private bool isClear; // 방 클리어 여부
    public bool IsClear
    { get { return isClear; } }

    public Room(int _number , bool _clear) // Room 생성자
    {
        roomNumber = _number;
        isClear = _clear;
    }

    public void ResetRoom() // Room 초기화
    {
        roomNumber = 0;
        isClear = false;
    }

    public void ChangeRoom(int after)
    {
        roomNumber = after;
    }

    public void RoomGenerator()
    {
        // 방사이즈가 같으니 
        // localPosition을 활용해서 오브젝트 와 몬스터 배치..
        // 설치할 오브젝트와 몬스터는 매개변수로 받아오기 ?
    }

}
