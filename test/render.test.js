const test = require("node:test");
const assert = require("node:assert");
const fs = require("fs");

const addon = require("../lib/zpl-renderer.node");

test("render png", () => {

    addon.initialize();

    const png = addon.renderPng(
        "^XA^FO50,50^FDHello^FS^XZ"
    );

    assert.ok(Buffer.isBuffer(Buffer.from(png)));

    assert.ok(png.length > 1000);

    fs.writeFileSync("test-output.png", Buffer.from(png));
});