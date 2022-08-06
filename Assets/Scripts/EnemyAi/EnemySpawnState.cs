using UnityEngine;

public class EnemySpawnState : EnemyBaseState
{
    public GameObject target;
    private GameObject targetHead;
    private Transform myTransform;
    private Vector3 directionToTarget;
    private float angle;
    public override void EnterState(EnemyStateMenager enemy)
    {
        getObjects(enemy);
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {
        calculateAngle();
        if(checkFov(enemy)) enemy.SwitchState(enemy.SeeState);
    }
    public override void OnCollisionEnter(EnemyStateMenager enemy, Collision collision)
    {

    }
    private void getObjects(EnemyStateMenager enemy)
    {
        target = GameObject.FindGameObjectWithTag("Player");
        enemy.target = target;
        targetHead = GameObject.FindGameObjectWithTag("MainCamera");
        myTransform = enemy.gameObject.transform;
    }
    private void calculateAngle()
    {
        directionToTarget = target.transform.position - myTransform.position;
        angle = Vector3.SignedAngle(directionToTarget, myTransform.forward, Vector3.up);
    }
    private bool checkFov(EnemyStateMenager enemy)
    {
        if (angle >= -90 && angle <= 90)
        {
            RaycastHit hit;
            if (Physics.Raycast(myTransform.position, directionToTarget, out hit) && hit.transform.gameObject == target)
            {
                return true;
            }
            else
            {
                if (Physics.Raycast(myTransform.position, targetHead.transform.position - myTransform.position, out hit) && hit.transform.gameObject == target)
                {
                    return true;
                }
                return false;
            }
        }
        return false;
    }
}
