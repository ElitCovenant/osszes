using KonyvtarKarbantarto;
using KonyvtarKarbantarto.Models;
using KonyvtarKarbantarto.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DatatransferTests
{
    [TestClass]
    public class KarbantartoTests
    {
        [TestMethod]
        [DataRow("05","5")]
        [DataRow("06","6")]
        [DataRow("10","10")]
        public void DateSecurerTestSuccess(string result,string input)
        {
            Assert.AreEqual(result, FelhasznaloEdit.SecurerDate(input));
        }

        [TestMethod]
        [DataRow("05", "Öt")]
        [DataRow("06", "Hat")]
        public void DateSecurerTestFaliure(string result, string input)
        {
            Assert.AreNotEqual(result, FelhasznaloEdit.SecurerDate(input));
        }

        [TestMethod]
        [DataRow(5, "5")]
        [DataRow(6, "6")]
        [DataRow(10, "10")]
        public void SecurerTest(int r,string i)
        {
            Assert.AreEqual(r, Konyvletrehozo.Securer(i));
        }

    }
}
