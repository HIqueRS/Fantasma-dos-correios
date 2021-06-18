using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShootTest
{
    [UnityTest]
    public IEnumerator Shoot()
    {
        GameObject gameObject;
        PlayerShoot playerShoot;

        gameObject = new GameObject();
        playerShoot = gameObject.AddComponent<PlayerShoot>();

        playerShoot.Initialize();
        playerShoot.Shoot( new Vector3(1,0));

       
        Assert.AreEqual(gameObject.transform.position,playerShoot._aux.transform.position);
        Assert.AreEqual(new Vector3(1, 0), playerShoot._aux.GetComponent<LetterBehaviour>().Direction);
        Assert.AreEqual(playerShoot._letterID%3, playerShoot._aux.GetComponent<LetterBehaviour>().LetterID);

        yield return null;
    }

    [UnityTest]
    public IEnumerator Change()
    {
        GameObject gameObject;
        PlayerShoot playerShoot;
        int id;

        gameObject = new GameObject();
        playerShoot = gameObject.AddComponent<PlayerShoot>();

        playerShoot.Initialize();

        id = playerShoot._letterID;

        playerShoot.ChangeLetter();


        Assert.AreEqual(id + 1, playerShoot._letterID);

        yield return null;
    }
}
