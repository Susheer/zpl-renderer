const fs = require("fs");
const path = require("path");

const paths = [
  "lib",
  "build",
  "managed/ZplRenderer.Core/bin",
  "managed/ZplRenderer.Core/obj"
];

for (const p of paths) {
  const fullPath = path.resolve(p);

  console.log(`Cleaning: ${fullPath}`);

  if (fs.existsSync(fullPath)) {
    fs.rmSync(fullPath, {
      recursive: true,
      force: true
    });

    console.log(`Deleted: ${fullPath}`);
  } else {
    console.log(`Not Found: ${fullPath}`);
  }
}

fs.mkdirSync("lib", { recursive: true });

console.log("Clean completed.");