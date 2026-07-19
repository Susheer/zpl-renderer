const fs = require("fs");
const path = require("path");

const libDir = path.join(__dirname, "lib");
const addonPath = path.join(libDir, "zpl-renderer.node");

const requiredFiles = [
    "zpl-renderer.node",
    "ZplRenderer.Core.dll",
    "libSkiaSharp.dll",
    "libHarfBuzzSharp.dll"
];

for (const file of requiredFiles) {
    const fullPath = path.join(libDir, file);

    if (!fs.existsSync(fullPath)) {
        throw new Error(
            `@thesusheer/zpl-renderer: Missing required runtime file:\n${fullPath}`
        );
    }
}

const addon = require(addonPath);

// Initialize once
addon.initialize();

module.exports = addon;