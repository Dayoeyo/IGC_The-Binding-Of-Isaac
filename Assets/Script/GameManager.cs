using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region �̱���
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public Room[,] StageStructure;

    public int stage; // ���� �������� 1 ~ 4
    public int stageSize; // �������� ������
    public int minimunRoomCount; // �������� �� �ּҰ���

    private void Start()
    {
        stage = 1; // �������� �ʱⰪ 1
        SetStage(); // ù �������� ����
    }


    public void SetStage() 
    {
        switch(stage)
        {
            case 1:
                stageSize = 5;
                minimunRoomCount = 8;
                break;
            case 2:
                stageSize = 5;
                minimunRoomCount = 8;
                break;
            case 3:
                stageSize = 7;
                minimunRoomCount = 10;
                break;
            case 4:
                stageSize = 7;
                minimunRoomCount = 12;
                break;
        }
    }
}
