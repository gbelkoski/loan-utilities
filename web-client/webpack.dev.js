const path = require("path");
const webpack = require('webpack');
const dotenv = require('dotenv');
const HtmlWebPackPlugin = require("html-webpack-plugin");

module.exports = () => {
  const env = dotenv.config().parsed;
  
  const envKeys = Object.keys(env).reduce((prev, next) => {
    prev[`process.env.${next}`] = JSON.stringify(env[next]);
    return prev;
  }, {});

  return {
    mode:'development',
    devServer: {
      publicPath:"/",
      contentBase: "./public",
      hot:true,
      historyApiFallback: true,
      port:3000
    },
    output: {
      path: path.join(__dirname, "public/dist/"),
      filename: "bundle.js",
      publicPath:'/'
    },
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          use: "ts-loader",
          exclude: /node_modules/
        },
        {
          test: /\.(jpg|jpeg|png|woff|woff2|eot|ttf)$/,
          loader: 'url-loader?limit=100000'
        },
        {
          test: /\.svg$/,
          use: [
            {
              loader: '@svgr/webpack',
              options: {
                native: false,
              }
            },
            {
              loader: 'url-loader'
            }
          ]
        }
      ]
    },
    plugins: [
      new webpack.DefinePlugin(envKeys),
      new HtmlWebPackPlugin({
        template:"./public/index.html"
      })
    ],
    resolve: {
      extensions: [".tsx", ".ts", ".js", ".woff", ".woff2", ".ttf"]
    }
  }
};