import * as monaco from 'monaco-editor';

window.editor = monaco.editor.create(document.getElementById('container'), {
    value: [
        'GPIO.setup(PIN[0], GPIO.IN)',
        'return GPIO.input(PIN[0])'
    ].join('\n'),
    language: 'python',
    theme: 'vs-dark'
});

var form = document.getElementById("code");
form.addEventListener("formdata", e =>
{
    e.formData.append('content', window.editor.getModel().getValue());
});