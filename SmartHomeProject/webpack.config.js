const MonacoWebpackPlugin = require('monaco-editor-webpack-plugin');
const path = require('path');

module.exports = {
    entry: './src/index.js',
    output: {
        path: path.resolve(__dirname, 'wwwroot/vscode'),
        filename: 'app.js',
        publicPath: "/vscode/"
    },
    module: {
        rules: [{
            test: /\.css$/,
            use: ['style-loader', 'css-loader']
        }, {
            test: /\.ttf$/,
            use: ['file-loader']
        }]
    },
    plugins: [
        new MonacoWebpackPlugin()
    ]
};