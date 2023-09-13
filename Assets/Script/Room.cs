using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    /* roomNumber
     * 1 : 시작방
     * 2 : 일반방
     * 3 : 보스방
     * 4 : 상점방
     * 5 : 황금방
     * 6 : 달방
     * roomNumber 변수의 수치에 맞춰서 방 오브젝트 배치.
     */

    public int roomNumber; // 방 종류 번호
    public bool isClear; // 방 클리어 여부

    public Room(int _number) // Room 생성자
    {
        roomNumber = _number;
        isClear = false;
    }

    public void ChangeRoom(int after)
    {
        roomNumber = after;
    }
}
