using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    /* roomNumber
     * 1 : ���۹�
     * 2 : �Ϲݹ�
     * 3 : ������
     * 4 : ������
     * 5 : Ȳ�ݹ�
     * 6 : �޹�
     * roomNumber ������ ��ġ�� ���缭 �� ������Ʈ ��ġ.
     */

    public int roomNumber; // �� ���� ��ȣ
    public bool isClear; // �� Ŭ���� ����

    //���� ���� ��ġ
    public int Y;
    public int X;
    public Room(int _number,int y, int x) // Room ������
    {
        roomNumber = _number;
        Y = y;
        X = x;
    }

    public void ChangeRoom(int after)
    {
        roomNumber = after;
    }
}
