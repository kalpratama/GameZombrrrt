using System.Collections;
using System.Collections.Generic;
using NUnit.Framework; // This is the testing library Unity uses.
using UnityEngine;
using UnityEngine.TestTools;

// This class will hold all our tests.
public class GameManagementTest
{
    // Test 1: A very simple test to make sure everything is working.
    // The [Test] attribute marks this method as a test.
    [Test]
    public void SimplePassesTest()
    {
        // Assert.Pass() is a simple way to make a test succeed.
        // It's useful for verifying that the test setup itself runs without errors.
        Assert.Pass("This test is designed to always pass.");
    }

    // Test 2: A more realistic test for a simple calculation.
    // Imagine you have a function that adds two numbers. This test verifies it works.
    [Test]
    public void AdditionTest()
    {
        // ARRANGE: Set up the variables for our test.
        int a = 5;
        int b = 10;
        int expectedResult = 15;

        // ACT: Run the code we are testing.
        // In a real scenario, this would be a function from your game's code,
        // for example: int actualResult = MyGameManager.AddNumbers(a, b);
        int actualResult = a + b;

        // ASSERT: Check if the result is what we expected.
        // Assert.AreEqual will compare the two values. If they are the same,
        // the test passes. If they are different, the test fails.
        Assert.AreEqual(expectedResult, actualResult, "The addition result was incorrect.");
    }
}