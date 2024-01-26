const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const postcssPresetEnv = require('postcss-preset-env');

const devMode = false;

module.exports = {
    mode: devMode ? 'development' : 'production',
    entry: [
        './src/js/app.js',
        './src/scss/site.scss'      // file nguồn  CSS
    ],

    output: {
        filename: 'app.min.js',
        path: path.resolve(__dirname, 'dist'),
        library: 'mylib',
        libraryTarget: 'var',
    },


    module: {
        rules: [
            {
                // Thiết lập build scss
                test: /\.(sa|sc)ss$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    {
                        // Interprets CSS
                        loader: 'css-loader',
                        options: {
                            importLoaders: 2
                        }
                    },
                    {
                        // minify CSS và thêm autoprefix
                        loader: 'postcss-loader',
                        options: {
                            ident: 'postcss',

                            // Đặt chế độ tối ưu
                            plugins: devMode
                                ? () => []
                                : () => [
                                    postcssPresetEnv({
                                        browsers: ['>1%']
                                    }),
                                    require('cssnano')()
                                ]
                        }
                    },
                    {
                        loader: 'sass-loader'
                    }
                ]
            },
            {
                // Thiết lập lưu các ảnh sử dụng bởi CSS
                // lưu dưới đường dẫn images cùng file site.css
                test: /\.(png|jpe?g|gif)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: '[name].[ext]',
                            // Image sử dụng bởi CSS lưu tại
                            publicPath: '../images',
                            emitFile: false
                        }
                    }
                ]
            }
        ]
    },

    plugins: [
        // Xuất kết quả với CSS - sau khi qua loader MiniCssExtractPlugin.loader
        new MiniCssExtractPlugin({
            filename: devMode ? 'css/site.css' : 'css/site.min.css'
        })
    ]
};