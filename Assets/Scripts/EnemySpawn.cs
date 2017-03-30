using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public int EnemyCount;

    public string KeyCodeEnemy;

    private PlayerData _data;

    public Enemy EnemyPrefab;
    private Enemy _enemy;

    // Use this for initialization
    void Start()
    {
        _data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(KeyCodeEnemy));
        EnemyCount = _data.CountEnemy;
        print(PlayerPrefs.GetString(KeyCodeEnemy));
        print(EnemyCount);
        for (int i = 0; i < _data.CountEnemy; i++)
        {
            _enemy = (Enemy)Instantiate(EnemyPrefab, new Vector3(Random.Range(-48f, 48f), 0.5f,
                Random.Range(-48f, 48f)), Quaternion.identity);
            _enemy.TextArea.text = _data.EnemyNames[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
