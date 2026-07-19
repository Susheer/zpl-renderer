const test = require("node:test");
const assert = require("node:assert");

const addon = require("../lib/zpl-renderer.node");

test("version format", () => {
    addon.initialize();

    const version = addon.getVersion();

    assert.match(version, /^\d+\.\d+\.\d+$/);
});