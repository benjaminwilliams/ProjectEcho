using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharacterAbilitySelector : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject pogiPrefab;
    public GameObject ardaPrefab;

    private bool characterSelected = false;
    private List<Ability> abilityList;
    private PlayerCharacter character;

    void OnGUI()
    {
        if (!characterSelected)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Pogi"))
            {
                SpawnPlayer(pogiPrefab);
            }
            if (GUI.Button(new Rect(400, 100, 300, 100), "Arda"))
            {
                SpawnPlayer(ardaPrefab);
            }
        }
        else
        {
            int xPos = 100;
            foreach(Ability ability in abilityList)
            {
                if (GUI.Button(new Rect(xPos, 100, 150, 60), ability.GetName()))
                {
                    character.enabled = true;
                    character.SetAbility(abilityList.IndexOf(ability));
                    if (Network.isServer)
                    {
                        SpawnBoss();
                    }
                    Destroy(this.gameObject);

                }
                xPos += 160;
            }
        }
    }

    private void SpawnPlayer(GameObject prefab)
    {
        character = ((GameObject)Network.Instantiate(prefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0)).GetComponent<PlayerCharacter>();
        character.enabled = false;
        abilityList = character.GetAbilities();
        characterSelected = true;
    }

    private void SpawnBoss()
    {
        GameObject boss = (GameObject)Network.Instantiate(bossPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
        boss.GetComponent<BossOne>().targetedEnemy = character.gameObject;
    }
}