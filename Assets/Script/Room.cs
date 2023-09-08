using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    /* roomNumber
     * 0 : ��������������
     * 1 : �Ϲݹ�
     * 2 : ���۹�
     * 3 : ������
     * 4 : ������
     * 5 : Ȳ�ݹ�
     * 6 : �޹�
     * roomNumber ������ ��ġ�� ���缭 �� ������Ʈ ��ġ.
     */

    private int roomNumber; // �� ���� ��ȣ
    public int RoomNumber
    { get { return roomNumber; } }
    private bool isClear; // �� Ŭ���� ����
    public bool IsClear
    { get { return isClear; } }

    public Room(int _number , bool _clear) // Room ������
    {
        roomNumber = _number;
        isClear = _clear;
    }

    public void ResetRoom() // Room �ʱ�ȭ
    {
        roomNumber = 0;
        isClear = false;
    }

    public void ChangeRoom(int after)
    {
        roomNumber = after;
    }
}
