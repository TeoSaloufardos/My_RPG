using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionHandler : MonoBehaviour
{
    [SerializeField] private GameObject regionalObject;
    [SerializeField] private GameObject regionalDeeds;

    enum  Region
    {
        WizardForest,
        Desert,
        Mountain,
        Village
    }

    private int outOfRegionKills;

    [SerializeField] private Region selectedRegion = new Region();

    private void Start()
    {
        regionalObject.SetActive(false);
        regionalDeeds.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
           switch (selectedRegion)
            {
                case Region.Desert:
                    SavePlayer.DsmallSkeletonKills = SavePlayer.smallSkeletonKills;
                    SavePlayer.smallSkeletonKills = 0;
                    SavePlayer.DbigSkeletonKills = SavePlayer.bigSkeletonKills;
                    SavePlayer.bigSkeletonKills = 0;
                    SavePlayer.DorcRiderKills = SavePlayer.orcRiderKills;
                    SavePlayer.orcRiderKills = 0;
                    SavePlayer.DpigKills = SavePlayer.pigKills;
                    SavePlayer.pigKills = 0;
                    SavePlayer.DcorrectAnswers = SavePlayer.correctAnswers;
                    SavePlayer.correctAnswers = 0;
                    regionalObject.SetActive(false);
                    regionalDeeds.SetActive(false);
                    break;
                case Region.Mountain:
                    SavePlayer.MsmallSkeletonKills = SavePlayer.smallSkeletonKills;
                    SavePlayer.smallSkeletonKills = 0;
                    SavePlayer.MbigSkeletonKills = SavePlayer.bigSkeletonKills;
                    SavePlayer.bigSkeletonKills = 0;
                    SavePlayer.MorcRiderKills = SavePlayer.orcRiderKills;
                    SavePlayer.orcRiderKills = 0;
                    SavePlayer.MpigKills = SavePlayer.pigKills;
                    SavePlayer.pigKills = 0;
                    SavePlayer.McorrectAnswers = SavePlayer.correctAnswers;
                    SavePlayer.correctAnswers = 0;
                    regionalObject.SetActive(false);
                    regionalDeeds.SetActive(false);
                    break;
                case Region.Village:
                    SavePlayer.VsmallSkeletonKills = SavePlayer.smallSkeletonKills;
                    SavePlayer.smallSkeletonKills = 0;
                    SavePlayer.VbigSkeletonKills = SavePlayer.bigSkeletonKills;
                    SavePlayer.bigSkeletonKills = 0;
                    SavePlayer.VorcRiderKills = SavePlayer.orcRiderKills;
                    SavePlayer.orcRiderKills = 0;
                    SavePlayer.VpigKills = SavePlayer.pigKills;
                    SavePlayer.pigKills = 0;
                    SavePlayer.VcorrectAnswers = SavePlayer.correctAnswers;
                    SavePlayer.correctAnswers = 0;
                    regionalObject.SetActive(false);
                    regionalDeeds.SetActive(false);
                    break;
                case Region.WizardForest:
                    SavePlayer.WsmallSkeletonKills = SavePlayer.smallSkeletonKills;
                    SavePlayer.smallSkeletonKills = 0;
                    SavePlayer.WbigSkeletonKills = SavePlayer.bigSkeletonKills;
                    SavePlayer.bigSkeletonKills = 0;
                    SavePlayer.WorcRiderKills = SavePlayer.orcRiderKills;
                    SavePlayer.orcRiderKills = 0;
                    SavePlayer.WpigKills = SavePlayer.pigKills;
                    SavePlayer.pigKills = 0;
                    SavePlayer.WcorrectAnswers = SavePlayer.correctAnswers;
                    SavePlayer.correctAnswers = 0;
                    regionalObject.SetActive(false);
                    regionalDeeds.SetActive(false);
                    break;
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            switch (selectedRegion)
            {
                case Region.Desert:
                    SavePlayer.smallSkeletonKills += SavePlayer.DsmallSkeletonKills;
                    SavePlayer.bigSkeletonKills += SavePlayer.DbigSkeletonKills;
                    SavePlayer.orcRiderKills += SavePlayer.DorcRiderKills;
                    SavePlayer.pigKills += SavePlayer.DpigKills;
                    SavePlayer.correctAnswers += SavePlayer.DcorrectAnswers;
                    regionalObject.SetActive(true);
                    regionalDeeds.SetActive(true);
                    break;
                case Region.Mountain:
                    SavePlayer.smallSkeletonKills += SavePlayer.MsmallSkeletonKills;
                    SavePlayer.bigSkeletonKills += SavePlayer.MbigSkeletonKills;
                    SavePlayer.orcRiderKills += SavePlayer.MorcRiderKills;
                    SavePlayer.pigKills += SavePlayer.MpigKills;
                    SavePlayer.correctAnswers += SavePlayer.McorrectAnswers;
                    StageOneMountain.playerJoinedToRegion = true;
                    regionalObject.SetActive(true);
                    regionalDeeds.SetActive(true);
                    break;
                case Region.Village:
                    SavePlayer.smallSkeletonKills += SavePlayer.VsmallSkeletonKills;
                    SavePlayer.bigSkeletonKills += SavePlayer.VbigSkeletonKills;
                    SavePlayer.orcRiderKills += SavePlayer.VorcRiderKills;
                    SavePlayer.pigKills += SavePlayer.VpigKills;
                    SavePlayer.correctAnswers += SavePlayer.VcorrectAnswers;
                    regionalObject.SetActive(true);
                    regionalDeeds.SetActive(true);
                    break;
                case Region.WizardForest:
                    SavePlayer.smallSkeletonKills += SavePlayer.WsmallSkeletonKills;
                    SavePlayer.bigSkeletonKills += SavePlayer.WbigSkeletonKills;
                    SavePlayer.orcRiderKills += SavePlayer.WorcRiderKills;
                    SavePlayer.pigKills += SavePlayer.WpigKills;
                    SavePlayer.correctAnswers += SavePlayer.WcorrectAnswers;
                    regionalObject.SetActive(true);
                    regionalDeeds.SetActive(true);
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Desert SK: " + SavePlayer.DsmallSkeletonKills);
            print("Global SK: " + SavePlayer.smallSkeletonKills);
            
            print("Desert BK: " + SavePlayer.DbigSkeletonKills);
            print("Global BK: " + SavePlayer.bigSkeletonKills);
        }
    }
}
