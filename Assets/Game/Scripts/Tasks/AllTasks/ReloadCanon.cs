using System;
using UnityEngine;

public class ReloadCanon : Task
{
    [SerializeField] Canons canon;

    public override void Awake()
    {
        base.Awake();
        onEndTask += LoadCanon;
    }

    private void OnDisable()
    {
        onEndTask -= LoadCanon;
    }

    void LoadCanon()
    {
        canon.isLoaded = true;
    }
}
