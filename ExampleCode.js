const path = require("path");
const fs = require("fs");
const addon = require("./lib/zpl-renderer.node");
const option = {
        labelWidth:101.6,
        labelHeight:152.4,
        printDensityDpmm:8,
        opaqueBackground:true
    }
console.log("process.cwd()", process.cwd());


console.log("addon.initialize() ",addon.initialize());
console.log("addon.getVersion()", addon.getVersion());
// const zpl = "^XA^FO50,50^FDHello^FS^XZ";
// console.log("addon.parse(zpl)", addon.parse(zpl));
// const png = addon.renderPng(zpl, option);
// console.log("PNG Size:", png.length);
// fs.writeFileSync("sample.png", Buffer.from(png));

const zz = addon.renderPng(`
^XA

^CI28

^PW812
^LL1218
^LH0,0

^FO20,20
^GB772,1178,4^FS

^FO40,40
^A0N,60,60
^FDTheSusheer Logistics Pvt Ltd^FS

^FO40,105
^A0N,30,30
^FDShipment Label^FS

^FO40,150
^GB730,2,2^FS

^FO40,180
^A0N,28,28
^FDOrder No:^FS
^FO220,180
^A0N,28,28
^FDORD-20260720-1001^FS

^FO40,220
^A0N,28,28
^FDCustomer:^FS
^FO220,220
^A0N,28,28
^FDSudheer Gupta^FS

^FO40,260
^A0N,28,28
^FDPhone:^FS
^FO220,260
^A0N,28,28
^FD+91 98765 43210^FS

^FO40,300
^A0N,28,28
^FDAddress:^FS

^FO220,300
^FB520,4,5,L,0
^A0N,28,28
^FDFlat 101, Sunshine Residency, Baner Road, Pune, Maharashtra 411045^FS

^FO40,430
^GB730,2,2^FS

^FO40,460
^BY3,3,120
^BCN,120,Y,N,N
^FD12345678901234567890^FS

^FO500,630
^BQN,2,8
^FDLA,https://github.com/thesusheer/zpl-renderer^FS

^FO40,630
^A0N,26,26
^FDScan QR to track shipment^FS

^FO40,760
^GB730,2,2^FS

^FO40,790
^A0N,26,26
^FDItems^FS

^FO40,830
^GB730,150,2^FS

^FO60,850
^A0N,24,24
^FD1 x Zebra Printer^FS

^FO60,885
^A0N,24,24
^FD2 x Thermal Labels Roll^FS

^FO60,920
^A0N,24,24
^FD5 x USB Cable^FS

^FO40,1010
^GB730,2,2^FS

^FO40,1040
^FR
^GB250,80,80,B,0^FS

^FO65,1060
^A0N,38,38
^FDPAID^FS

^FO350,1045
^A0R,32,32
^FDROTATED TEXT^FS

^FO450,1040
^A0N,22,22
^FDGenerated using^FS

^FO450,1070
^A0N,28,28
^FD@thesusheer/zpl-renderer^FS

^XZ
`, {
    labelWidth: 101.6,
    labelHeight: 152.4,
    printDensityDpmm: 8,
    opaqueBackground: true
});

fs.writeFileSync("barcode.png", Buffer.from(zz));

console.log("sample.png written");