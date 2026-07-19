test("invalid zpl", () => {

    addon.initialize();

    assert.doesNotThrow(() => {

        addon.parse("THIS IS NOT ZPL");

    });

});