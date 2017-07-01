﻿'use strict';

var path = require('path');
var webpack = require('webpack');
var merge = require('webpack-merge');
var CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;

module.exports = function (env) {
    // Configuration in common to both client-side and server-side bundles
    var isDevBuild = !(env && env.prod);
    var sharedConfig = {
        stats: { modules: false },
        context: __dirname,
        resolve: { extensions: ['.js', '.ts'] },
        output: {
            filename: '[name].js',
            publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
        },
        module: {
            rules: [{ test: /\.ts$/, include: /ClientApp/, use: ['awesome-typescript-loader?silent=true', 'angular2-template-loader'] }, { test: /\.html$/, use: 'html-loader?minimize=false' }, { test: /\.css$/, use: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize'] }, { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' }]
        },
        plugins: [new CheckerPlugin()]
    };

    // Configuration for client-side bundle suitable for running in browsers
    var clientBundleOutputDir = './wwwroot/dist';
    var clientBundleConfig = merge(sharedConfig, {
        entry: { 'main-client': './ClientApp/boot-client.ts' },
        output: { path: path.join(__dirname, clientBundleOutputDir) },
        plugins: [new webpack.DllReferencePlugin({
            context: __dirname,
            manifest: require('./wwwroot/dist/vendor-manifest.json')
        })].concat(isDevBuild ? [
        // Plugins that apply in development builds only
        new webpack.SourceMapDevToolPlugin({
            filename: '[file].map', // Remove this line if you prefer inline source maps
            moduleFilenameTemplate: path.relative(clientBundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
        })] : [
        // Plugins that apply in production builds only
        new webpack.optimize.UglifyJsPlugin()])
    });

    // Configuration for server-side (prerendering) bundle suitable for running in Node
    var serverBundleConfig = merge(sharedConfig, {
        resolve: { mainFields: ['main'] },
        entry: { 'main-server': './ClientApp/boot-server.ts' },
        plugins: [new webpack.DllReferencePlugin({
            context: __dirname,
            manifest: require('./ClientApp/dist/vendor-manifest.json'),
            sourceType: 'commonjs2',
            name: './vendor'
        })],
        output: {
            libraryTarget: 'commonjs',
            path: path.join(__dirname, './ClientApp/dist')
        },
        target: 'node',
        devtool: 'inline-source-map'
    });

    return [clientBundleConfig, serverBundleConfig];
};

