using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    int[] dy = new int[4] { -1, 0, 1, 0 };
    int[] dx = new int[4] { 0, 1, 0, -1 };

    Room[,] stageArr; // �������� ����
    List<GameObject> roomList; // ������ ����� �������� ����Ʈ

    [Header("Unity SetUp")]
    public Transform stagePool; // �ش� ������Ʈ ������ ������������ ����
    public GameObject[] roomPrefabs;

    void Start()
    {
        roomList = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("test");
            CreateMap(GameManager.instance.stageSize); // show
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("test");
            ResetMap();
            CreateStage(); // ����
        }
    }

    public void CreateStage() // �������� ����
    {
        GameManager.instance.SetStage();

        // �������� ������ �ʿ��� ��
        int minimunRoomCount = GameManager.instance.minimunRoomCount;
        int stageSize = GameManager.instance.stageSize;

        // �������� ���� �ʱ�ȭ.
        stageArr = new Room[stageSize, stageSize];

        // �������� ������ �߸��Ǿ����� ����
        int cnt = 10;
        while (cnt-- >= 0)
        {
            if (CreateStructure(stageSize, minimunRoomCount)) // ������ �� �Ǿ�����
            {
                if (SelectRoom(stageSize))
                {
                    break;
                }
            }
            stageArr = new Room[stageSize, stageSize]; // �迭 �ʱ�ȭ
        }
    }

    bool CreateStructure(int size, int min)
    {
        int roomCount = 1;

        int midY = size / 2; // �߾�
        int midX = size / 2; // �߾�

        stageArr[midY, midX] = new Room(1); // ���۹� ����

        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>(); // {y,x}
        q.Enqueue(new KeyValuePair<int, int>(midY, midX));

        while(q.Count != 0) // ť�� ��������.
        {
            KeyValuePair<int, int> qFront = q.Dequeue(); // ť���� ��� ����

            int y = qFront.Key; // y��
            int x = qFront.Value; // x��

            for(int i = 0; i < 4; i++)
            {
                int ny = y + dy[i]; // ������ġ���� ���� y��
                int nx = x + dx[i]; // ������ġ���� ���� x��

                if (ny < 0 || nx < 0 || ny >= size || nx >= size) // ������ continue;
                    continue;
                if(stageArr[ny,nx] == null) //���������������̶��
                {
                    // ���� ������ ��ġ�� ������ ���� ���� 
                    int adjCnt = CheckAbjRoom(ny, nx, size);
                    if (adjCnt >= 2) // 2�� �̻��̸� �� ���� �Ұ���
                        continue;

                    // ����� ���� ( ���� )
                    int randomValue = Random.Range(0, 3);
                    if (randomValue == 0) // �����ϰ� ������ ���� 0�̸� 
                        continue; // ���������ʴ´�.

                    stageArr[ny, nx] = new Room(2); // ���ȣ 1������ ����� ( �Ϲ� )
                    roomCount++;
                    q.Enqueue(new KeyValuePair<int, int>(ny, nx)); // q�� ����ֱ�.

                }
            }
        }
        if (roomCount >= min) // ������ �� ������ �ּ� �氳���� ������
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

            if (ny < 0 || nx < 0 || ny >= size || nx >= size) // ������ continue
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
                if (stageArr[i, j] == null) // ����°�
                {   }
                else if (stageArr[i, j].roomNumber == 1) // �Ϲݹ�
                {
                    GameObject obj = Instantiate(roomPrefabs[0], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 2) // ���۹�
                {
                    GameObject obj = Instantiate(roomPrefabs[1], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 3) // ������
                {
                    GameObject obj = Instantiate(roomPrefabs[2], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 4) // ������
                {
                    GameObject obj = Instantiate(roomPrefabs[3], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 5) // Ȳ�ݹ�
                {
                    GameObject obj = Instantiate(roomPrefabs[4], createRoomPosition, Quaternion.identity, stagePool) as GameObject;
                    roomList.Add(obj);
                }
                else if (stageArr[i, j].roomNumber == 6) // �޹�
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
        int[] roomNumber = { 3,4,5,6 }; // ����, ����, Ȳ��, �޹�

        List<KeyValuePair<int, int>> temp = new List<KeyValuePair<int, int>>();
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                if (stageArr[i, j] == null || stageArr[i,j].roomNumber == 1) // ���̾��°� or ���۹��̸� continue;
                    continue;

                int adj = CheckAbjRoom(i, j, size);
                if(adj == 1) // ������ ���� 1���ۿ�������  ����,����, Ȳ��,�޹� ���� ���� O
                    temp.Add(new KeyValuePair<int, int>(i, j));
            }
        }

        if (temp.Count < 4) // 4�� �̸��̸� 
            return false;
        // 3�� �̻��̸� �� ������ true ����
        for(int i = 0; i < 4; i++)
        {
            if(i == 3) // �޹� �����϶�
            {
                // ���� Ȯ�� �־���!
                int r = Random.Range(0, 2);
                if (r == 0)
                    continue;
            }

            int randNumber = Random.Range(0, temp.Count);
            // temp[randNumber].Key  : Y
            // temp[randNumber].value  : X
            stageArr[temp[randNumber].Key, temp[randNumber].Value].ChangeRoom(roomNumber[i]);
            temp.RemoveAt(randNumber);
        }
        return true;
    }

}
