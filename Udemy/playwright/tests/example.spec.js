const { test, expect } = require("@playwright/test");

test.describe.parallel("smoke test group", () => {
  test.beforeEach(async ({ page }) => {
    await page.goto("https://playwright.dev");
  });
  test("First Test @smoke", async ({ page, browserName }) => {
    // testing code here
    test.skip(browserName === "firefox", "need to fix firefox issue");
    await page.goto("https://playwright.dev");
    var title = page.locator(".navbar__inner .navbar__title");
    await expect(title).toHaveText("Playwright");
    // await page.pause();
  });

  test("Click Test @regression", async ({ page }) => {
    //await page.goto("https://the-internet.herokuapp.com/");
    await page.goto("/");
    // await page.locator("text=Add/Remove Elements").click();
    // //await page.pause();
    // await page.locator("text=Add Element").click();
    // //await page.pause();

    // await page.click("text=Add Element");
    //await page.pause();
  });
  // annotations
  test("Duplicate Test", async ({ page }) => {
    await page.goto("https://the-internet.herokuapp.com/");
    await page.locator("text=Add/Remove Elements").click();
    //await page.pause();
  });
});

// next lecture = Playwright configs
