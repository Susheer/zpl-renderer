test("integration", () => {

    addon.initialize();

    const json =
        JSON.parse(addon.parse("^XA^FO50,50^FDHello^FS^XZ"));

    const png =
        addon.renderPng("^XA^FO50,50^FDHello^FS^XZ");

    assert.ok(json.labelInfos);

    assert.ok(png.length > 1000);

});