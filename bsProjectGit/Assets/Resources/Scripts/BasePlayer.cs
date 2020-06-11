using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasePlayer : MonoBehaviour
{
    private NavMeshAgent naviMesh;
    private Queue<Vector3> poses = new Queue<Vector3>();
    private enum State
    {
        None=0,
        SetPos,
        Walk,
    }
    private int state;
    void Start()
    {
        naviMesh = GetComponent<NavMeshAgent>();
        poses.Enqueue(new Vector3(1, 0, 1f));
        poses.Enqueue(new Vector3(49, 0, 1f));
        poses.Enqueue(new Vector3(49, 0, 49f));
        poses.Enqueue(new Vector3(1, 0, 49f));
        state = (int)State.None;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (int)State.None:
                state = (int)State.SetPos;
                break;
            case (int)State.SetPos:
                naviMesh.SetDestination(poses.Peek());
                state = (int)State.Walk;
                break;
            case (int)State.Walk:
                if(Vector3.Distance(transform.position, poses.Peek())<=0.3f)
                {
                    //把第一个数据放到最后并删除他
                    poses.Enqueue(poses.Peek());
                    poses.Dequeue();
                    state = (int)State.SetPos;
                }
                break;
                
        }
    }
}
