test("100 parses", () => {

    addon.initialize();

    for(let i=0;i<100;i++){

        addon.parse("^XA^FO50,50^FDHello^FS^XZ");

    }

});