import { chromium } from "@playwright/test";

async function myWebScrapper() {
  let browser = await chromium.launch();
  let context = await browser.newContext();
  let page = await context.newPage();
}
