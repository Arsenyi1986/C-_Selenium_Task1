using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Pages;

public class PastebinPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public PastebinPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private By codeInput = By.Id("postform-text");
    private By pasteNameInput = By.Id("postform-name");
    private By createPasteButton = By.XPath("//button[contains(text(), 'Create New Paste')]");

    public void TextInput(string input)
    {
        driver.FindElement(codeInput).SendKeys(input);
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void ExpSelection()
    {
        
        By expirationDropdown = By.Id("select2-postform-expiration-container");

        driver.FindElement(expirationDropdown).Click();

        By expirationOption = By.XPath("/html/body/span[2]/span/span[2]/ul/li[3]");

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(expirationOption));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(expirationOption));

    
        driver.FindElement(expirationOption).Click();
    }

    public void InputName(string name)
    {
        driver.FindElement(pasteNameInput).SendKeys(name);
    }

    public void Submit()
    {
        driver.FindElement(createPasteButton).Click();
    }
}
