using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : BossBaseState
{
    public BossRun(BossStateMachine currentContext,BossStateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        if(_context._canDoMeleeAttack){
            SwitchState(_factory.NormalAttack());
        }else{
            if(_context._canRushInAttack){
                SwitchState(_factory.RushInAttack());
            }
        }
    }

    public override void EnterState()
    {
        _exitState = false;
        //_context.Anim.CrossFade("run",1);
        _context.Anim.Play("run");
    }

    public override void ExitState()
    {
        _context.TurnOffNavMesh();
    }

    public override void UpdateState()
    {
        if(_exitState){
            Debug.Log("Exit state is true");
            return;
        }
        if(_context.PlayerPosition != null){
            _context._bossAgent.speed = 3;
        _context._bossAgent.SetDestination(_context.PlayerPosition.position);
        }
        
        CheckSwitchState();
    }
}
