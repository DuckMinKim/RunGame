using UnityEngine;

// 발판을 생성하고 주기적으로 재배치하는 스크립트
public class PlatformSpawner : MonoBehaviour {
    public GameObject[] Platforms;
    public int spawnIndex;

    public Transform point;
    float platform_Y;
    public float YMax, YMin;

    public float count;
    float times;

    void Start() {
        SpawnPlatforms();
        spawnIndex = 1;
        times = count;
    }

    void Update() {

        if (times>0)
            times -= Time.deltaTime;
        if (times <= 0)
            SpawnPlatforms();

        for(int i = 0; i < 3; i++)
        {
            if (Platforms[i].transform.position.x < -15.5f)
            {
                Platforms[i].SetActive(false);
            }
        }
    }
    public void SpawnPlatforms()
    {
        Platforms[spawnIndex].transform.position = point.transform.position + new Vector3(0, platform_Y, 0);
        Platforms[spawnIndex].SetActive(true);
        Platform p = Platforms[spawnIndex].GetComponent<Platform>();
        p.StepReset();

        platform_Y = Random.Range(YMin, YMax);
        if (spawnIndex >= 2)
            spawnIndex = 0;
        else
            spawnIndex++;
        times = count;
    }
}