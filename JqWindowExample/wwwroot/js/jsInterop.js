window.jsInterop = {
    writeToConsole: function (input) {
        console.log(input);
    },
    showPrompt: function (text) {
        return prompt(text, 'Type your name here');
    },
    displayWelcome: function (welcomeMessage) {
        document.getElementById('welcome').innerText = welcomeMessage;
    },
    returnArrayAsyncJs: function () {
        DotNet.invokeMethodAsync('DayPilot', 'ReturnArrayAsync', 'chugga')
            .then(data => {
                data.push(4);
                console.log(data);
            });
    },
    sayHello: function (dotnetHelper) {
        return dotnetHelper.invokeMethodAsync('SayHello', 'gorp')
            .then(r => console.log(r));
    }
};