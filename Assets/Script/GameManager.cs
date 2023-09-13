using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region 싱글톤
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

    public int stage; // 현재 스테이지 1 ~ 4
    public int stageSize; // 스테이지 사이즈
    public int minimunRoomCount; // 스테이지 방 최소개수

    private void Start()
    {
        stage = 1; // 스테이지 초기값 1
        SetStage(); // 첫 스테이지 세팅
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
