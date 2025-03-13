using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossStateMachine : MonoBehaviour
{
    [SerializeField] private float viewRadius;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private float _attackRadius;
    public bool SawPlayer = false;
    private BossStateFactory _state;
    public BossBaseState CurrentState;
    public Animator Anim;
    public NavMeshAgent _bossAgent;
    public TurnOnCollider ArmCollider;
    public TurnOnCollider BodyCollider;
    public TurnOnCollider RushInCollider;
    public bool _canDoMeleeAttack = false;
    public bool _canRushInAttack = false;
    public Transform PlayerPosition;
    void Awake()
    {
        _state = new BossStateFactory(this);
    }
    void Start()
    {
        BodyCollider.PlayerHasDetected += PlayerInNormalAttackRange;
        ArmCollider.PlayerHasDetected += HitPlayer;
        RushInCollider.PlayerHasDetected += CanRushInPlayer;
        CurrentState = _state.Idle();
        //CurrentState.EnterState();
    }
    void Update()
    {
        CurrentState.UpdateState();
    }

    private void FindingPlayer()

    {
        //bool isInRange = false;
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, _playerMask);
        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < 60 / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    SawPlayer = true;
                    break;
                }

            }

        }

    }
    private void PlayerInNormalAttackRange(bool detect)
    {
        _canDoMeleeAttack = detect;
    }
    private void HitPlayer(bool hasHit)
    {
        if (hasHit)
        {
            // cause dame to player
            Debug.Log("hit the player");
        }
    }
    public bool AnimatorIsPlaying(float ratio = 0.9f)
    {
        return Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < ratio;
    }

    private void CanRushInPlayer(bool canRushIn)
    {
        _canRushInAttack = canRushIn;
    }

    public void TurnOffNavMesh()
    {
        _bossAgent.isStopped = true;
        _bossAgent.ResetPath(); // Clears the current path
        _bossAgent.velocity = Vector3.zero; // Stops any remaining movement
        //_bossAgent.enabled = false; // Now disable the agent
    }
    public void TurnOnNavMesh()
    {
        _bossAgent.enabled = true;
    }
}
