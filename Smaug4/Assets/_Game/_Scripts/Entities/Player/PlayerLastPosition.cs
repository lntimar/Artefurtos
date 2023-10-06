using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLastPosition : MonoBehaviour
{
    #region Vari�veis Globais
    [SerializeField] private float registerTimer;
    public static Vector3 Position { get; private set; }
    #endregion

    #region Fun��es Unity

    private void Awake() => Position = transform.position;

    private void Start() => StartCoroutine(RegisterLastPosition(registerTimer));

    #endregion

    #region Fun��es Pr�prias

    private IEnumerator RegisterLastPosition(float interval)
    {
        yield return new WaitForSeconds(registerTimer);
        Position = transform.position;
    }

    #endregion
}
