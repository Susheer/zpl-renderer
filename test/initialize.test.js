const test = require("node:test");
const assert = require("node:assert");

const addon = require("../lib/zpl-renderer.node");

test("initialize succeeds", () => {
    assert.strictEqual(addon.initialize(), true);
});