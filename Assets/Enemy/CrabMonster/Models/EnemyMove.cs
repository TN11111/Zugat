using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); // NavMeshAgentを保持しておく
    }

    public void Update()
    {
        // 検知したオブジェクトに「Player」のタグがついていれば、そのオブジェクトを追いかける
        _agent.destination = playerController.transform.position;
    }


    // CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        
    }
}