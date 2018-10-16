using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;
using NUnit.Framework;
using System.Collections;
using Ramirez;

public class RamirezUnityTests
{

    [Test]
    public void CopyModifiers()
    {
        GameObject source = GameObject.Find("source");
        GameObject destiny = GameObject.Find("destiny");
        GameObject stranger = GameObject.Find("stranger");

        DoUnity.CopyModifiers(source, destiny);

        Assert.AreEqual(source.transform.position, destiny.transform.position, "Positions should be equal");
        Assert.AreEqual(source.transform.localScale, destiny.transform.localScale, "Scales should be equal");
        Assert.AreEqual(source.transform.localPosition, destiny.transform.localPosition, "localPosition should be equal");
        Assert.True(source.transform.localRotation == destiny.transform.localRotation, "localRotation should be equal");
        Assert.True(source.transform.rotation == destiny.transform.rotation, "rotation should be equal");
        Assert.AreEqual(source.transform.localScale, destiny.transform.localScale, "localScale should be equal");


        Assert.AreNotEqual(stranger.transform.position, destiny.transform.position, "Positions should be different");
        Assert.AreNotEqual(stranger.transform.localScale, destiny.transform.localScale, "Scales should be different");
        Assert.AreNotEqual(stranger.transform.localPosition, destiny.transform.localPosition, "localPosition should be different");
        Assert.False(stranger.transform.localRotation == destiny.transform.localRotation, "localRotation should be different");
        Assert.False(stranger.transform.rotation == destiny.transform.rotation, "rotation should be different");
        Assert.AreNotEqual(stranger.transform.localScale, destiny.transform.localScale, "localScale should be different");


        Assert.AreNotEqual(stranger.transform.position, Vector3.zero, "Positions should be different");
        Assert.AreNotEqual(stranger.transform.localScale, Vector3.zero, "Scales should be different");
        Assert.AreNotEqual(stranger.transform.localPosition, Vector3.zero, "localPosition should be different");
        Assert.False(stranger.transform.localRotation == Quaternion.identity, "localRotation should be different");
        Assert.False(stranger.transform.rotation == Quaternion.identity, "rotation should be different");
        Assert.AreNotEqual(stranger.transform.localScale, Vector3.zero, "localScale should be different");
    }


    [Test]
    public void GetGreatest()
    {
        Assert.AreEqual(DoUnity.GetGreatest(new Vector3(4, 5, 6)), 6, "Get 6 as greatest from (4,5,6)");
        Assert.AreEqual(DoUnity.GetGreatest(new Vector3(-4, -Mathf.Infinity, 0)), 0, "Get 0 as greatest from (-4, -Mathf.Infinity, 0)");
        Assert.AreEqual(DoUnity.GetGreatest(new Vector3(1.2f, 1.2222f, 1.222222f)), 1.222222f, "Get 1.222222 as greatest from (1.2f, 1.2222f, 1.222222f)");

    }

    [Test]
    public void GetSmallest()
    {
        Assert.AreEqual(DoUnity.GetSmallest(new Vector3(4, 5, 6)), 4, "Get 4 as greatest from (4,5,6)");
        Assert.AreEqual(DoUnity.GetSmallest(new Vector3(-4, -Mathf.Infinity, 0)), -Mathf.Infinity, "Get 0 as greatest from (-4, -Mathf.Infinity, 0)");
        Assert.AreEqual(DoUnity.GetSmallest(new Vector3(1.2f, 1.2222f, 1.222222f)), 1.2f, "Get 1.222222 as greatest from (1.2f, 1.2222f, 1.222222f)");
        Assert.AreEqual(DoUnity.GetSmallest(new Vector3(10e-4f, 10e-6f, 10e-8f)), 10e-8f, "Get 4 as greatest from (10e-4f, 10e-6f, 10e-8f)");

    }

    [Test]
    public void HideChildren()
    {
        GameObject parent = GameObject.Find("parent");
        //Assert there are children and that they are visible
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Assert.Greater(children.Length, 1);
        foreach (Transform c in children)
        {
            Assert.True(c.GetComponent<Renderer>().enabled);
        }

        DoUnity.HideChildren(parent);
        foreach (Transform c in children)
        {
            Assert.False(c.GetComponent<Renderer>().enabled);
        }

    }

    [Test]
    public void ShowChildren()
    {
        GameObject parent = GameObject.Find("parent");
        //Assert there are children and that they are invisible
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Assert.Greater(children.Length, 1);
        foreach (Transform c in children)
        {
            c.GetComponent<Renderer>().enabled = false;
            Assert.False(c.GetComponent<Renderer>().enabled);
        }

        DoUnity.ShowChildren(parent);
        foreach (Transform c in children)
        {
            Assert.True(c.GetComponent<Renderer>().enabled);
        }

    }

}
