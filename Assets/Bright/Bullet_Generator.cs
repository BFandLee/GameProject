using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Generator : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Start()
    {
        // 1초마다 BulletSpawn 함수 호출
        InvokeRepeating("BulletSpawn", 1.0f, 0.5f);
    }

    void BulletSpawn()
    {
        // 화면 상단 무작위 위치 계산
        float randomX = Random.Range(-12.0f, 50.41f);
        Vector3 spawnPosition = new Vector3(randomX, 10.0f, 0.0f);

        // bullet_0Prefab을 생성하여 무작위 위치에 떨어뜨림
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }
}
