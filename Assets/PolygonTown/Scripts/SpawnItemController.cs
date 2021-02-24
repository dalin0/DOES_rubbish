using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemController : MonoBehaviour
{
    public Transform[] SpawnPoints; // 生成一个坐标的阵列
    public float spawnTime = 1f; // 多久生成
    public GameObject[] Items; // 装生成的道具
    // Start is called before the first frame update
    int i = 0;
    public bool flag = false;
    void Start()
    {
        SpawnItems();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void SpawnItems() {
        
        for(i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(Items[i], SpawnPoints[i].position, SpawnPoints[i].rotation); // 生成随机物
        }
        //int spawnIndex = Random.Range(0, SpawnPoints.Length);
        //int ItemIndex = Random.Range(0, Items.Length);
        
        
    }
}
