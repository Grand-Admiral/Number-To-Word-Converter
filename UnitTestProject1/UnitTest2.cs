using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void SetTest()
        {
            string result = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";
            Assert.AreEqual(result, Class1.ConvertNumbersToWords("123.45"));
        }

        [TestMethod]
        public void TestFinal2()
        {
            string result = "ONE HUNDRED AND ELEVEN DOLLARS";
            Assert.AreEqual(result, Class1.ConvertNumbersToWords("111"));
        }

        [TestMethod]
        public void TestFinal3()
        {
            string result = "ONE HUNDRED AND NINETY DOLLARS AND SEVENTY-SEVEN CENTS";
            Assert.AreEqual(result, Class1.ConvertNumbersToWords("190.77"));
        }

        //--------
        //note 1002030.40.05 = 100 20 3 0.4 0.05
        [TestMethod]
        public void TestToNum1()
        {
            string result = "1002030.40.05";
            int i = 0;
            string a = "";
            while (i <= 4)
            {
                a += Class1.ToNums("123.45")[i];
                i++;
            }
            Assert.AreEqual(result, a);
        }

        [TestMethod]
        public void TestToNum2()
        {
            string result = "04070.30.02"; //test if 100 zero registers
            int i = 0;
            string a = "";
            while (i <= 4)
            {
                a += Class1.ToNums("47.32")[i];
                i++;
            }
            Assert.AreEqual(result, a);
        }

        [TestMethod]
        public void TestToNum3()
        {
            string result = "1009000.70.07"; //test that zero registers
            int i = 0;
            string a = "";
            while (i <= 4)
            {
                a += Class1.ToNums("190.77")[i];
                i++;
            }
            Assert.AreEqual(result, a);
        }

        [TestMethod]
        public void TestToNum4()
        {
            string result = "00000"; //test that zero registers
            int i = 0;
            string a = "";
            while (i <= 4)
            {
                a += Class1.ToNums("0")[i];
                i++;
            }
            Assert.AreEqual(result, a);
        }

        //------

        [TestMethod]
        public void TestToWord1()
        {
            string result = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";
            string[] data = { "100", "20", "3", "0.4", "0.05" };
            Assert.AreEqual(result, Class1.ToWords(data));
        }

        [TestMethod]
        public void TestToWord2()
        {
            string result = "THREE HUNDRED AND TWENTY DOLLARS AND FORTY CENTS";
            string[] data = { "300", "20", "0", "0.4", "0" };
            Assert.AreEqual(result, Class1.ToWords(data));
        }

        [TestMethod]
        public void TestToWord3()
        {
            string result = "ONE HUNDRED AND ELEVEN DOLLARS";
            string[] data = { "100", "10", "1", "0", "0" };
            Assert.AreEqual(result, Class1.ToWords(data));
        }

        [TestMethod]
        public void TestToWord4()
        {
            string result = "ONE HUNDRED AND ELEVEN DOLLARS AND ELEVEN CENTS";
            string[] data = { "100", "10", "1", "0.1", "0.01" };
            Assert.AreEqual(result, Class1.ToWords(data));
        }
    }
}
