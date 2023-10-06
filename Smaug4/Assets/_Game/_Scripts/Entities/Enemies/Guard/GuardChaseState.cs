using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardChaseState : GuardState
{
    #region Vari�veis Globais
    private Transform _playerTransform;
    #endregion

    #region Fun��es Pr�prias
    public GuardChaseState(Transform playerTransform)
    {
        this._playerTransform = playerTransform;
    }

    public override void Execute()
    {
        base.Execute();
        base.StateMachine.Agent.SetDestination(_playerTransform.position);
    }

    #endregion
}
