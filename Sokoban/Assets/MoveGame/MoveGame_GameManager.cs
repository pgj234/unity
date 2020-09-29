using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGame_GameManager : MonoBehaviour {
    [SerializeField] GameObject carPrefab;
    [SerializeField] GameObject airPlanePrefab;

    [SerializeField] int carNum;
    [SerializeField] int airPlaneNum;

    IMover[] movers;

    void Start() {

        movers = new IMover[4];
        movers[0] = CreateAirPlane();
        movers[1] = CreateCar();
        movers[2] = CreateCar();
        movers[3] = CreateCar();

        Car CreateCar() {
            GameObject carObj = Instantiate(carPrefab);
            carObj.transform.position = new Vector3(RandomIntFuc(-20, 20), 0f, RandomIntFuc(-2, 20));
            carObj.transform.Rotate(0f, RandomIntFuc(0, 359), 0f);

            return carObj.GetComponent<Car>();
        }

        AirPlane CreateAirPlane() {
            GameObject airPlaneObj = Instantiate(airPlanePrefab);
            airPlaneObj.transform.position = new Vector3(RandomIntFuc(-20, 20), 10f, RandomIntFuc(-2, 20));
            airPlaneObj.transform.Rotate(0f, RandomIntFuc(0, 359), 0f);

            return airPlaneObj.GetComponent<AirPlane>();
        }
    }

    int RandomIntFuc(int minNum, int maxNum) {
        return Random.Range(minNum, maxNum +1);
    }

    public void AllStop() {
        for (int i=0; i<movers.Length; i++) {
            movers[i].Stop();
        }
    }
}