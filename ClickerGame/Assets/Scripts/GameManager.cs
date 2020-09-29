using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singletone<GameManager> {
    // 1. 처치한 적의 수, 적 등장한 이후 지난 시간, 적을 처치하는데 주어진 시간
    // 2. 적 스폰(), 적이 죽었을 때 시간 처리(), 총 처치한 적의 수 카운팅()

    [SerializeField] Player player;
    [SerializeField] Pet pet;

    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform spawnEnemyPos;
    [SerializeField] UIManager uiManager;

    int playerCoin;
    int PlayerCoin {
        set {
            playerCoin = value;
            PlayerPrefs.SetInt("Coin", playerCoin);
            uiManager.UpdateCoin(playerCoin);
        }
        get {
            return playerCoin;
        }
    }

    Enemy curEnemy;

    int deadEnemy;
    int DeadEnemy {
        set {
            deadEnemy = value;
            uiManager.UpdateKillCount(deadEnemy);
        }
        get {
            return deadEnemy;
        }
    }

    const float timeForKillEnemy = 5f;
    float curTime;

    const int levelUpPrice = 20;

    void Start() {
        playerCoin = PlayerPrefs.GetInt("Coin", 0);
        DeadEnemy = 0;
        curTime = 0;

        SpawnEnemy();

        uiManager.UpdatePlayerLevelUpButton(player.Lv,
                                            player.totalDamage,
                                            player.GetNextDamage(1),
                                            player.Lv * levelUpPrice);

        uiManager.UpdateEnemyLevelUpButton(Enemy.Lv * levelUpPrice);

        uiManager.UpdatePetLevelUpButton(pet.Lv,
                                        pet.totalDamage,
                                        pet.GetNextDamage(1),
                                        pet.Lv * levelUpPrice);
    }

    void Update() {
        SpendTime();
    }

    void SpendTime() {
        if (curEnemy == null || curEnemy.isDead == true) {
            return;
        }

        curTime += Time.deltaTime;
        uiManager.UpdateTime(timeForKillEnemy, curTime);

        if (curTime >= timeForKillEnemy) {
            curTime = 0;

            // 실패에 대한 처리
            curEnemy.DisAppear();
            Invoke("SpawnEnemy", 2.5f);
        }
    }

    void SpawnEnemy() {
        curTime = 0;
        uiManager.UpdateTime(timeForKillEnemy, curTime);

        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        GameObject enemyObj = Instantiate(enemyPrefabs[randomIndex], spawnEnemyPos);
        curEnemy = enemyObj.GetComponent<Enemy>();
        curEnemy.Encounter(10);

        player.SetTarget(curEnemy);
        pet.SetTarget(curEnemy);
    }

    public void UpdateEnemyDie(int getCoin) {
        DeadEnemy += 1;
        PlayerCoin += getCoin;

        Invoke("SpawnEnemy", 2.5f);
    }

    public void UpdatePlayerLevel(int upLevel) {
        if (UpdateAttackerLevel<Player>(player, upLevel)) {
            uiManager.UpdatePlayerLevelUpButton(player.Lv,
                                                player.totalDamage,
                                                player.GetNextDamage(upLevel),
                                                player.Lv * levelUpPrice);
        }
    }

    public void UpdateEnemyLevel(int upLevel) {
        int price = Enemy.Lv * levelUpPrice;

        if (PlayerCoin >= price) {
            PlayerCoin -= price;

            Enemy.Lv += upLevel;
            price = Enemy.Lv * levelUpPrice;
            uiManager.UpdateEnemyLevelUpButton(price);
        }
    }

    public void UpdatePetLevel(int upLevel) {
        if (UpdateAttackerLevel<Pet>(pet, upLevel)) {
            uiManager.UpdatePetLevelUpButton(pet.Lv,
                                            pet.totalDamage,
                                            pet.GetNextDamage(upLevel),
                                            pet.Lv * levelUpPrice);
        }
    }

    // Generic
    bool UpdateAttackerLevel<A>(A attacker, int upLevel) where A : Attacker {
        int price = attacker.Lv * levelUpPrice;

        if (PlayerCoin >= price) {
            PlayerCoin -= price;

            attacker.UpdateLevel(upLevel);

            return true;
        }
        else {
            return false;
        }
    }

    void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Remove")) {
            PlayerPrefs.DeleteAll();
        }
    }
}