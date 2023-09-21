using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform movePosition;
    public GameObject roomInfo;

    [Header("Unity Setup")]
    public GameObject closeDoor;
    public GameObject openDoor;

    private void Start()
    {
        closeDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(roomInfo.GetComponent<Room>().isClear) // 방이 클리어된상태 일때
        {
            if(collision.gameObject.CompareTag("Player")) // 문에 부딪힌 대상이 플레이어라면
            {
                collision.transform.position = movePosition.transform.position; // 플레이어를 이동
            }
        }
    }
}
