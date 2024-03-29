using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CallGuards : MonoBehaviour
{
    #region Vari�veis Globais
    // Unity Inspector:
    [Header("Configura��es:")]
    [SerializeField] private bool isCamera = false;
    [SerializeField] private float maxAlertProgress;
    [SerializeField] private float alertIncrement;
    [SerializeField] private float alertDecrement;

    // Modificador do Progresso de Alerta:
    public enum AlertModifier { Decrease, Increase, Maximize }

    // Alert:
    private float _currentAlertProgress;
    #endregion

    #region Fun��es Unity
    //private void Update() => print(_currentAlertProgress);
    #endregion

    #region Fun��es Pr�prias
    public void ChangeAlertProgress(AlertModifier modifier)
    {
        if (modifier == AlertModifier.Increase)
        {
            _currentAlertProgress = Mathf.Clamp(_currentAlertProgress + alertIncrement * Time.deltaTime, 0f, maxAlertProgress);

            if (_currentAlertProgress >= maxAlertProgress) // Player totalmente avistado
            {
                // Chamar os Guardas
                ChangeGuards();

                // Caso for uma Camera
                if (isCamera)
                    GetComponent<CameraRotation>().Stop();
            }
        }
        else if (modifier == AlertModifier.Decrease)
        {
            _currentAlertProgress = Mathf.Clamp(_currentAlertProgress - alertDecrement * Time.deltaTime, 0f, maxAlertProgress);

            //Caso for uma Camera
            if (isCamera)
                GetComponent<CameraRotation>().Restart();
        }
        else
        {
            _currentAlertProgress = maxAlertProgress;
        }
    }

    public void ResetAlertProgress() => _currentAlertProgress = 0f;
    
    private void ChangeGuards()
    {
        foreach (var g in GuardBehaviour.Guards) 
            g.SetState(GuardBehaviour.GuardStates.Chase);
    }
    #endregion
}
