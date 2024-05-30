import { test, expect } from "@playwright/test";

test("test asdasd Name",
  {
    tag: ["@smoke", "@2344"],
    annotation: {
      description: "test1",
      type: "smoke",
    },
  },
  async ({ page, request, context }) => {
    await page.goto('https://playwright.dev/');
    let myVar = "adasdasd";
    await expect(page).toHaveTitle(/Playwright/);

  }
);
test.describe("my Main test suit", ()=>{
  test("test 223 Name",
  {
    tag: ["@smoke", "@2344"],
    annotation: {
      description: "test1",
      type: "smoke",
    },
  },
  async ({ page, request, context }) => {
    await page.goto('https://playwright.dev/');
    let myVar = "adasdasd";
    await expect(page).toHaveTitle(/Playwright/);

  }
  );
})
