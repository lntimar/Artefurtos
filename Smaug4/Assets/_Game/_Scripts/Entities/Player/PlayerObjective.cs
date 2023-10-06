using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObjective : MonoBehaviour
{
    #region Vari�veis Globais:
    // Refer�ncias:
    private CollisionLayersManager _collisionLayersManager;

    // Tesouros coletados:
    private List<Sprite> _currentTreasureSprites = new List<Sprite>();
    private int _treasuresLeft;
    #endregion

    #region Fun��es Unity

    private void Awake()
    {
        _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();
        _treasuresLeft = GameObject.FindObjectsOfType<TreasureBehaviour>().Length;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_currentTreasureSprites.Count > 0 && col.gameObject.layer == _collisionLayersManager.Backpack.Index)
            RemoveTreasure();
    }
    #endregion

    #region Fun��es Pr�prias
    public void AddTreasure(Sprite newTreasureSprite) => _currentTreasureSprites.Add(newTreasureSprite);

    public void RemoveTreasure()
    {
        _currentTreasureSprites.RemoveAt(0);
        _treasuresLeft--;

        if (_treasuresLeft <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   
    #endregion
}
