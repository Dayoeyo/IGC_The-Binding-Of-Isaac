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

    public Room(int _number) // Room ������
    {
        roomNumber = _number;
        isClear = false;
    }

    public void ChangeRoom(int after)
    {
        roomNumber = after;
    }
<<<<<<< Updated upstream
=======

    public void RoomGenerator()
    {
        
    }

>>>>>>> Stashed changes
}
