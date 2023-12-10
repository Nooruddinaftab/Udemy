using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;

    List<Transform> waypointList;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypointList = waveConfig.GetWaypoints();
        transform.position = waypointList[waypointIndex].transform.position;
    }

    public void SetWaveConfig(WaveConfig waveCfg)
    {
        this.waveConfig = waveCfg;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (waypointIndex <= (waypointList.Count - 1))
        {
            var targetPosition = waypointList[waypointIndex].transform.position;
            var movementThisFmae = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFmae);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
