using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;
using System;

namespace Tests;

[TestFixture]
public class Tests
{
    private ChromeDriver driver;
    private PastebinPage pastebinPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://pastebin.com");

        pastebinPage = new PastebinPage(driver);
    }

    [Test]
    public void NewPaste()
    {
        pastebinPage.TextInput("Hello from WebDriver");
        pastebinPage.ExpSelection();
        pastebinPage.InputName("helloweb");
        pastebinPage.Submit();

        Assert.IsTrue(driver.Url.Contains("pastebin.com"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}