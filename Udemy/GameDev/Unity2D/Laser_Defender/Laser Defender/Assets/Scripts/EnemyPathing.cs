using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypointList;
    [SerializeField] float moveSpeed = 2f;


    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypointList[waypointIndex].transform.position;
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
            var movementThisFmae = moveSpeed * Time.deltaTime;
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
