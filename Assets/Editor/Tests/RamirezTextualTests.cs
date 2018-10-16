using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Ramirez;

public class RamirezTextualTests
{

    [Test]
    public void RemoveDiacritics()
    {
        Assert.AreEqual("AcUcar", DoText.RemoveDiacritics("ÀçÛcãr"), "Respect case");
        Assert.AreEqual("Strasse", DoText.RemoveDiacritics("Straße"), "Replace accents");
        Assert.AreEqual("«»", DoText.RemoveDiacritics("«»"), "Do not remove characters without accent");

    }

    [Test]
    public void SplitSentences()
    {
        string phrase = "A mighty woman with a torch, whose flame Is the imprisoned lightning, and her name Mother of Exiles. From her beacon-hand Glows world-wide welcome; her mild eyes command The air-bridged harbor that twin cities frame.";
        string[] resultA = {
             "A mighty woman with a torch, whose flame Is the imprisoned lightning, and her name Mother of Exiles.",
             "From her beacon-hand Glows world-wide welcome; her mild eyes command The air-bridged harbor that twin cities frame."
        };

        Assert.AreEqual(DoText.SplitSentences(phrase), resultA, "Split sentences");

        phrase = "“I feel like a wet seed wild in the hot blind earth.”";
        string[] resultB = {
             "“I feel like a wet seed wild in the hot blind earth.”"
        };

        Assert.AreEqual(DoText.SplitSentences(phrase), resultB, "Return single item array if phrase cannot be split.");

        phrase = "Cada palabra tenía un signo particular, una especie de marca; las últimas eran muy complicadas... Yo traté de explicarle que esa rapsodia de voces inconexas era precisamente lo contrario de un  sistema  de  numeración.";
        
        string[] resultC = {
             "Cada palabra tenía un signo particular, una especie de marca; las últimas eran muy complicadas...",
             "Yo traté de explicarle que esa rapsodia de voces inconexas era precisamente lo contrario de un  sistema  de  numeración."
        };

        Assert.AreEqual(DoText.SplitSentences(phrase), resultC, "Split by ellipsis");


        phrase = "Cada palabra tenía un signo particular, una especie de marca; las últimas eran muy complicadas… Yo traté de explicarle que esa rapsodia de voces inconexas era precisamente lo contrario de un  sistema  de  numeración.";
        
        string[] resultD = {
             "Cada palabra tenía un signo particular, una especie de marca; las últimas eran muy complicadas…",
             "Yo traté de explicarle que esa rapsodia de voces inconexas era precisamente lo contrario de un  sistema  de  numeración."
        };

        Assert.AreEqual(DoText.SplitSentences(phrase), resultD, "Split by ellipsis, even if they are a single character");

        
        phrase = "";
        
        Assert.AreEqual(DoText.SplitSentences(phrase), null, "Empty phrase null array, such is life.");

        

    }

}
