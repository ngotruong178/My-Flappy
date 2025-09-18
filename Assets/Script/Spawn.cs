using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject PipeFPrefab;
    [SerializeField] private Transform SpawnPos;
    [SerializeField] private float timeSpawn = 2f;
    private float lastSpawn = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPipe();
    }
    public void SpawnPipe()
    {
        if (Time.time >= lastSpawn + timeSpawn)
        {
            lastSpawn = Time.time;
            Vector3 pos = SpawnPos.position;
            pos.y = Random.Range(-1.78f, 1.6f);
            GameObject pipe = Instantiate(PipeFPrefab, pos, Quaternion.identity);
            Destroy(pipe, 5f);
        }
    }
}
