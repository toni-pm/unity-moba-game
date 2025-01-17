﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSamuzaiE : Action
{
    private int speed;

    // Use this for initialization
    void Start()
    {
        this.speed = 13;
        this.timeOut = 2;
    }


    void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;
        if (otherGO != this.skill.gameObject)
        {
            CombatSystem otherCS = other.GetComponent<CombatSystem>();
            CombatSystem myCS = this.skill.GetCombatSystem();
            if (otherCS != null && myCS != null)
            {
                if (otherCS.GetTeam() != myCS.GetTeam())
                {
                    this.skill.Return(other.gameObject);
                    this.photonView.RPC("AutoDestroy", PhotonTargets.All, null);
                }
            }
        }
    }

    protected override void Tick()
    {
        this.transform.position += this.transform.forward * this.speed * Time.deltaTime;
    }
}
