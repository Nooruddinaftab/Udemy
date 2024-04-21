import { test, expect } from "@playwright/test";

test("test", async ({ page }) => {
  await page.goto("https://the-internet.herokuapp.com/");
  await page.getByRole("link", { name: "Context Menu" }).click();
  await page.locator("#hot-spot").click();
  await page.locator("#content").click();
  await page.locator("#hot-spot").click();
  await page.locator("#hot-spot").click();
  await page.getByText("Context menu items are custom").click();
  await page.getByText("Right-click in the box below").click();
  await page.locator("#hot-spot").click();
  await page.locator("#hot-spot").dblclick();
  await page.locator("#hot-spot").click();
  await page.locator("#page-footer").click();
  await page.locator("#hot-spot").click({
    clickCount: 4,
  });
  await page.locator("#hot-spot").click();
  await page.locator("#hot-spot").click();
  await page.locator("#hot-spot").click();
  await page.getByText("Context menu items are custom").click();
  await page.getByRole("heading", { name: "Context Menu" }).click();
  await page.getByText("Context menu items are custom").click({
    button: "right",
  });
  await page.getByText("Context menu items are custom").click();
  await page.getByText("Context Menu Context menu").click();
  await page.locator("#hot-spot").click();
  await page.locator("#page-footer").click({
    button: "right",
  });
  await page.locator("div").filter({ hasText: "Powered by Elemental Selenium" }).nth(1).click();
});
