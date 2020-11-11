let jqxWindowList = [];
window.jqxWindowComponent = {
    initialize: function (instanceId, jqxWindowJsInterop) {
        console.log("jqxWindowComponent.initialize");
        $('#' + instanceId).jqxWindow({
            theme: 'darkblue',
            autoOpen: true,
            resizable: true,
            showCloseButton: false
        });

        jqxWindowList[instanceId] = $('#' + instanceId);
        jqxWindowJsInterop.invokeMethodAsync('OnJqxWindowInitializedJs');
    },
    close: function (instanceId) {
        console.log("jqxWindowComponent.close");
        jqxWindowList[instanceId].jqxWindow('close');
    },
    open: function (instanceId) {
        console.log("jqxWindowComponent.open");
        jqxWindowList[instanceId].jqxWindow('open');
    },
    dispose: function (instanceId) {
        console.log('jqxWindowComponent.dispose : ' + instanceId);
        if ($('#' + instanceId).length) {
            $('#' + instanceId).jqxWindow('destroy');
        }
        delete jqxWindowList[instanceId];       
    },
};