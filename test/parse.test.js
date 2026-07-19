const test = require("node:test");
const assert = require("node:assert");

const addon = require("../lib/zpl-renderer.node");

test("parse hello label", () => {

    addon.initialize();

    const result = JSON.parse(
        addon.parse("^XA^FO50,50^FDHello^FS^XZ")
    );

    assert.ok(result);

    assert.ok(result.labelInfos);

    assert.strictEqual(result.errors.length,0);
});