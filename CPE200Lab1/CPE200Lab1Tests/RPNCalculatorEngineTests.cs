﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPE200Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1.Tests
{
    [TestClass()]
    public class RPNCalculatorEngineTests
    {
        RPNCalculatorEngine engine;

        [TestInitialize()]
        public void Initialize()
        {
            engine = new RPNCalculatorEngine();
        }

        [TestMethod()]
        public void ConstructorTest()
        {
            Assert.IsNotNull(engine);
            Assert.IsInstanceOfType(engine, typeof(RPNCalculatorEngine));
        }

        [TestMethod()]
        public void EmptyArgumentTest()
        {
            Assert.AreEqual("E", engine.calculate(null)); // what we want program to do
            Assert.AreEqual("E", engine.calculate("")); // what the program actually do
        }

        [TestMethod()]
        public void BasicCalcuationOneTest()
        {
            Assert.AreEqual("0", engine.calculate("0"));

            Assert.AreEqual("2", engine.calculate("1 1 + "));
            Assert.AreEqual("0", engine.calculate("1 1 - "));
            Assert.AreEqual("1", engine.calculate("1 1 X "));
            Assert.AreEqual("1", engine.calculate("1 1 ÷ "));
        }

        [TestMethod()]
        public void BasicCalcuationTwoTest()
        {
            Assert.AreEqual("10", engine.calculate("5 5 + "));
            Assert.AreEqual("10", engine.calculate("20 10 - "));
            Assert.AreEqual("10", engine.calculate("5 2 X "));
            Assert.AreEqual("10", engine.calculate("10 1 ÷")); // this one
        }

        [TestMethod()]
        public void BasicCalcuationThreeTest()
        {
            Assert.AreEqual("20", engine.calculate("10 10 + "));
            Assert.AreEqual("-10", engine.calculate("10 20 - "));
            Assert.AreEqual("100", engine.calculate("10 10 X "));
            Assert.AreEqual("10", engine.calculate("100 10 ÷"));
        }

        [TestMethod()]
        public void BasicCalcuationFourTest()
        {
            Assert.AreEqual("-1", engine.calculate("1 2 - "));
            Assert.AreEqual("-1", engine.calculate("-1 1 X "));
            Assert.AreEqual("-1", engine.calculate("1 -1 X "));
            Assert.AreEqual("-1", engine.calculate("1 -1 ÷"));
            Assert.AreEqual("-1", engine.calculate("-1 1 ÷"));
        }

        [TestMethod()]
        public void BasicCalcuationFiveTest()
        {
            Assert.AreEqual("0.5", engine.calculate("1 2 ÷ "));
            Assert.AreEqual("0.3333", engine.calculate("1 3 ÷ "));
            Assert.AreEqual("0.25", engine.calculate("1 4 ÷ "));
            Assert.AreEqual("0.1667", engine.calculate("1 6 ÷ "));// ปัดทศนิยม
            Assert.AreEqual("0.125", engine.calculate("1 8 ÷ "));
        }

        [TestMethod()]
        public void ComplexCalcuationTest()
        {
            Assert.AreEqual("3", engine.calculate("1 1 1 + + "));
            Assert.AreEqual("-1", engine.calculate("1 1 1 + - "));
            Assert.AreEqual("1", engine.calculate("1 1 1 - + "));
            Assert.AreEqual("1", engine.calculate("1 1 1 - - "));
            Assert.AreEqual("6", engine.calculate("2 2 2 X + "));
            Assert.AreEqual("8", engine.calculate("2 2 2 + X "));
            Assert.AreEqual("0.5", engine.calculate("2 2 2 + ÷"));
            Assert.AreEqual("3", engine.calculate("2 2 2 ÷ +"));
        }

        [TestMethod()]
        public void DividedByZeroTest()
        {
           // Assert.AreEqual(engine.calculate("0 0 ÷ "),"E" ); able to swap the parametors
            Assert.AreEqual("E", engine.calculate("0 0 ÷ "));
            Assert.AreEqual("E", engine.calculate("1 0 ÷ "));
            Assert.AreEqual("E", engine.calculate("1 2 2 - ÷ "));
        }

        [TestMethod()]
        public void InvalideFormatTest()
        {
            Assert.AreEqual("E", engine.calculate("+"));
            Assert.AreEqual("E", engine.calculate("1+"));
            Assert.AreEqual("E", engine.calculate("+1"));
            Assert.AreEqual("E", engine.calculate("1 +"));
            Assert.AreEqual("E", engine.calculate("+ 1"));
            Assert.AreEqual("E", engine.calculate("1 1"));
            Assert.AreEqual("E", engine.calculate("+ 1 1"));
            Assert.AreEqual("E", engine.calculate("1 1 ++"));
            Assert.AreEqual("E", engine.calculate("1 1 + +"));
            Assert.AreEqual("E", engine.calculate("1 1 ++ +"));
            Assert.AreEqual("E", engine.calculate("1 1 + + +"));
            Assert.AreEqual("E", engine.calculate("1 1 1 + "));
            Assert.AreEqual("E", engine.calculate("1 1 1 + "));
        }
    }
}