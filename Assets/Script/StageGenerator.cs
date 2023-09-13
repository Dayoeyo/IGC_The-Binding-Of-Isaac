using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    int[] dy = new int[4] { -1, 0, 1, 0 };
    int[] dx = new int[4] { 0, 1, 0, -1 };

    Room[,] stageArr; // 스테이지 구조
    List<GameObject> roomList; // 생성된 방들을 관리해줄 리스트

    [Header("Unity SetUp")]
    public Transform stagePool; // 해당 오브젝트 하위로 스테이지들을 생성
    public GameObject[] roomPrefabs;

    void Start()
    {
        roomList = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetMap();
            CreateStage(); // 생성
            CreateMap(GameManager.instance.stageSize); // show
        }
    }

    public void CreateStage() // 스테이지 생성
    {
        GameManager.instance.SetStage();

        // 스테이지 생성에 필요한 값
        int minimunRoomCount = GameManager.instance.minimunRoomCount;
        int stageSize = GameManager.instance.stageSize;

        // 스테이지 구조 초기화.
        stageArr = new Room[stageSize, stageSize];

        // 스테이지 생성이 잘못되었을때 리롤
        int cnt = 10;
        while (cnt-- >= 0)
        {
            if (CreateStructure(stageSize, minimunRoomCount)) // 생성이 잘 되었을때
            {
                if (SelectRoom(stageSize))
                {
                    break;
                }
            }
            stageArr = new Room[stageSize, stageSize]; // 배열 초기화
        }
    }

    bool CreateStructure(int size, int min)
    {
        int roomCount = 1;

        int midY = size / 2; // 중앙
        int midX = size / 2; // 중앙

        stageArr[midY, midX] = new Room(1,midY, midX); // 시작방 설정

        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>(); // {y,x}
        q.Enqueue(new KeyValuePair<int, int>(midY, midX));

        while(q.Count != 0) // 큐가 빌때까지.
        {
            KeyValuePair<int, int> qFront = q.Dequeue(); // 큐에서 요소 빼기

            int y = qFront.Key; // y값
            int x = qFront.Value; // x값

            for(int i = 0; i < 4; i++)
            {
                int ny = y + dy[i]; // 현재위치에서 다음 y값
                int nx = x + dx[i]; // 현재위치에서 다음 x값

                if (ny < 0 || nx < 0 || ny >= size || nx >= size) // 범위밖 continue;
                    continue;
                if(stageArr[ny,nx] == null) //생성하지않은방이라면
                {
                    // 방을 생성할 위치에 인접한 방의 개수 
                    int adjCnt = CheckAbjRoom(ny, nx, size);
                    if (adjCnt >= 2) // 2개 이상이면 방 생성 불가능
                        continue;

                    // 방생성 여부 ( 랜덤 )
                    int randomValue = Random.Range(0, 3);
                    if (randomValue == 0) // 랜덤하게 생성한 수가 0이면 
                        continue; // 생성하지않는다.

                    stageArr[ny, nx] = new Room(2,ny,nx); // 방번호 2번으로 방생성 ( 일반방 )
                    roomCount++;
                    q.Enqueue(new KeyValuePair<int, int>(ny, nx)); // q에 담아주기.

                }
            }
        }
        if (roomCount >= min) // 생성된 방 개수가 최소 방개수를 넘으면
            return true;
        return false;
    }
    int CheckAbjRoom(int y, int x, int size)
    {
        int ret = 0;

        for(int i = 0; i < 4; i++)
        {
            int ny = y + dy[i];
            int nx = x + dx[i];

            if (ny < 0 || nx < 0 || ny >= size || nx >= size) // 범위밖 continue
                continue;

            if (stageArr[ny, nx] == null)
                continue;

            ret++;
        }

        return ret;
    }
    void ResetMap()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }

    void CreateMap(int size)
    {
        Vector3 createRoomPosition = new Vector3(0, 0, 0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (stageArr[i, j] == null) // 방없는곳
                {   }
                else if (stageArr[i, j].roomNumber == 1) // 일반방
                {
                    GameObject obj = Instantiate(roomPrefabs[0], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 2) // 시작방
                {
                    GameObject obj = Instantiate(roomPrefabs[1], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 3) // 보스방
                {
                    GameObject obj = Instantiate(roomPrefabs[2], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 4) // 상점방
                {
                    GameObject obj = Instantiate(roomPrefabs[3], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 5) // 황금방
                {
                    GameObject obj = Instantiate(roomPrefabs[4], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 6) // 달방
                {
                    GameObject obj = Instantiate(roomPrefabs[5], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                createRoomPosition += new Vector3(10, 0, 0);
            }
            createRoomPosition = new Vector3(0, createRoomPosition.y, 0);
            createRoomPosition += new Vector3(0, -7, 0);
        }
    }
    bool SelectRoom(int size)
    {
        int[] roomNumber = { 3,4,5,6 }; // 보스, 상점, 황금, 달방

        List<KeyValuePair<int, int>> temp = new List<KeyValuePair<int, int>>();
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                if (stageArr[i, j] == null || stageArr[i,j].roomNumber == 1) // 방이없는곳 or 시작방이면 continue;
                    continue;

                int adj = CheckAbjRoom(i, j, size);
                if(adj == 1) // 인접한 방이 1개밖에없으면  보스,상점, 황금,달방 생성 조건 O
                    temp.Add(new KeyValuePair<int, int>(i, j));
            }
        }

        if (temp.Count < 4) // 4개 미만이면 
            return false;
        // 3개 이상이면 방 선택후 true 리턴
        for(int i = 0; i < 4; i++)
        {
            if(i == 3) // 달방 순서일때
            {
                // 대충 확률 넣어줌!
                int r = Random.Range(0, 2);
                if (r == 0)
                    continue;
            }

            int randNumber = Random.Range(0, temp.Count);
            stageArr[temp[randNumber].Key, temp[randNumber].Value].ChangeRoom(roomNumber[i]);
            temp.RemoveAt(randNumber);
        }
        return true;
    }

}
