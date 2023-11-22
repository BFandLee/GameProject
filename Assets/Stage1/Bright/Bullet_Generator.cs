using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Generator : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Start()
    {
        // 1�ʸ��� BulletSpawn �Լ� ȣ��
        InvokeRepeating("BulletSpawn", 1.0f, 0.5f);
    }

    void BulletSpawn()
    {
        // ȭ�� ��� ������ ��ġ ���
        float randomX = Random.Range(-12.0f, 50.41f);
        Vector3 spawnPosition = new Vector3(randomX, 10.0f, 0.0f);

        // bullet_0Prefab�� �����Ͽ� ������ ��ġ�� ����߸�
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }
}
