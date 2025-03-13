using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public BossIdleState(BossStateMachine currentContext,BossStateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        (BossBaseState action, double probability)[] actions = {
            (_factory.NormalAttack(), 0.8),  
            (_factory.SpecialAttack(),  0.2)
            
        };

        (BossBaseState action, double probability)[] actions2 = {
            (_factory.RushInAttack(), 0.3),  
            (_factory.SpecialAttack(),  0.2),
            (_factory.Run(),  0.5)
            
        };


        if(_context._canDoMeleeAttack){
            SwitchState(_factory.GetRandomOutcome(actions));
        }else{
            SwitchState(_factory.Run());
        }
    }

    public override void EnterState()
    {
        _exitState = false;
        //_context.Anim.CrossFade("idle",1);
        _context.Anim.Play("idle");
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        if(_exitState){
            return;
        }
        CheckSwitchState();
    }
}
