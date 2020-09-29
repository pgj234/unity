using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChanger : MonoBehaviour {
    // Equipment equipment;

    [SerializeField] Warm warm;
    [SerializeField] GameObject[] equipmentPrefabs;

    // 0 : 바주카 (Bazoka)
    // 1 : 나이프 (Knife)
    // 2 : 수류탄 (Granade)
    // 3 : 권총 (Pistol)
    // 4 : 지뢰 (LandMine)
    // 5 : 머신건 (MachineGun)
    // 6 : 화염방사기 (FlameThrower)
    // 7 : 블래스터 (Blaster)
    // 8 : 융단 폭격 (AerialBombing)
    // 9 : 콘크리트 아머킷 (ConcreteArmorKit)
    // 10 : 텔레포트 건 (TeleportGun)
    // 11 : 구급상자 (MediKit)

    public void ItemChange(int equipNum) {
        warm.CurEquipmentDestroy();
        Debug.Log("디스트로이");
        
        warm.EquipmentCreate(equipmentPrefabs[equipNum]);
        Debug.Log("생성");
    }
}
