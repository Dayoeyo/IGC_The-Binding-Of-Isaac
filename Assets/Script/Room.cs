using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{
    /* roomNumber
     * 0 : ��������������
     * 1 : �ӽ� ����
     * 2 : ���۹�
     * 3 : �Ϲݹ�
     * 4 : ������
     * 5 : ������
     * 6 : Ȳ�ݹ�
     * 7 : �޹�
     * roomNumber ������ ��ġ�� ���缭 �� ������Ʈ ��ġ.
     */
    int roomNumber; // �� ���� ��ȣ
    int isClear; // Ŭ���� ����

    Room(int _number) // Room ������
    {
        roomNumber = _number;
    }
}
