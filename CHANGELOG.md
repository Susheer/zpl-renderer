# Changelog

## 0.1.0

- Initial project structure
- ZPL parser
- PNG rendering
- Image export

## 0.2.0

- SVG renderer
- Font improvements

## 0.3.0 
complete call chain is
```
Node.js
↓
require("zpl-renderer.node")
↓
NODE_API_MODULE()
↓
addon.cc
↓
ZplRenderer
↓
LoadLibrary()
↓
ZplRenderer.Core.dll
↓
Managed NativeAOT
```