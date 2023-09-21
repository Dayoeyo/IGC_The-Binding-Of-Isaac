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
        if(roomInfo.GetComponent<Room>().isClear) // ���� Ŭ����Ȼ��� �϶�
        {
            if(collision.gameObject.CompareTag("Player")) // ���� �ε��� ����� �÷��̾���
            {
                collision.transform.position = movePosition.transform.position; // �÷��̾ �̵�
            }
        }
    }
}
