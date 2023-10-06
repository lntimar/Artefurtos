using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAlertState : GuardState
{
    #region Vari�veis Globais
    private Vector3 _lastPlayerPos;
    #endregion

    #region Fun��es Pr�prias
    public GuardAlertState(Vector3 lastPlayerPos)
    {
        _lastPlayerPos = lastPlayerPos;
    }

    public override void Execute()
    {
        base.Execute();
        base.StateMachine.Agent.SetDestination(_lastPlayerPos);

        if (base.HasReachPoint())
        {
            // Chame a fun��o que troque a dire��o em que o guarda est� olhando
        }
    }
    #endregion
}
