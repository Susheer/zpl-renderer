const path = require("path");
const fs = require("fs");

console.log(process.cwd());

console.log(
    fs.existsSync(
        path.join(__dirname, "lib", "ZplRenderer.Core.dll")
    )
);

const addon = require("./lib/zpl-renderer.node");

console.log(addon.initialize());
console.log(addon.getVersion());
const zpl = "^XA^FO50,50^FDHello^FS^XZ";
console.log(addon.parse(zpl));