test("memory", () => {

    addon.initialize();

    for(let i=0;i<1000;i++){

        addon.renderPng("^XA^FO50,50^FDHello^FS^XZ");

    }

});