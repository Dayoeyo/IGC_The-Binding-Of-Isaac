using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{
    /* roomNumber
     * 0 : 배정되지않은곳
     * 1 : 임시 배정
     * 2 : 시작방
     * 3 : 일반방
     * 4 : 보스방
     * 5 : 상점방
     * 6 : 황금방
     * 7 : 달방
     * roomNumber 변수의 수치에 맞춰서 방 오브젝트 배치.
     */
    int roomNumber; // 방 종류 번호
    int isClear; // 클리어 여부

    Room(int _number) // Room 생성자
    {
        roomNumber = _number;
    }
}
