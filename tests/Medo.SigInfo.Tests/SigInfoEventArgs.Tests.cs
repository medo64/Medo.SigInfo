using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medo;

namespace Tests;

[TestClass]
public class SigInfoEventArgs_Tests {

    [TestMethod]
    public void SigInfoEventArgs_New() {
        var e = new SigInfoEventArgs();
        Assert.AreEqual(string.Empty, e.OutputText);
    }

    [TestMethod]
    public void SigInfoEventArgs_Append() {
        var e = new SigInfoEventArgs();
        e.AppendOutputText("Hello");
        e.AppendOutputText("World");
        Assert.AreEqual("Hello" + Environment.NewLine + "World", e.OutputText);
    }

}
