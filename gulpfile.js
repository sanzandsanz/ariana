var gulp = require('gulp');
var tm = require('bgtm')(gulp);
var scss = require('bgtm-engine-scss');
var js = require('bgtm-engine-js');
var images = require('bgtm-engine-images');

var config = {
    src: 'src/Ariana.Presentation/',
    dest: 'publish/static/'
};

tm.add('scss', {
    runOnBuild: true,
    watch: true,
    watchSource: [
        config.src + 'css/**/*.scss'
    ],
    liveReload: true,
    engine: scss,
    engineOptions: {
        'src': config.src + 'css/*.scss',
        'dest': config.dest + 'css/'
    }
});

tm.add('js', {
    runOnBuild: true,
    watch: true,
    watchSource: [
        config.src + 'js/**/*.js'
    ],
    liveReload: true,
    engine: js,
    engineOptions: {
        'src': [
            'node_modules/jquery/dist/jquery.min.js',
            'node_modules/popper.js/dist/umd/popper.min.js',
            'node_modules/bootstrap/dist/js/boostrap.min.js',
            config.src + 'js/vendor/*.js'
        ],
        'dest': config.dest + 'js/',
        'outputFileName': 'main.js'
    }
});

tm.add('images', {
    runOnBuild: true,
    watch: true,
    watchSource: [
        config.src + 'images/**/*'
    ],
    liveReload: true,
    engine: images,
    engineOptions: {
        'src': config.src + 'images/**/*',
        'dest': config.dest + 'images/'
    }
});

tm.run();