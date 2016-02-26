/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify');

var path = {
    webroot: "./wwwroot/",
    css: {
        bootstrap: "./bower_components/bootstrap/dist/css/bootstrap.css",
        fontAwesome: "./bower_components/font-awesome/css/font-awesome.css",
        awesomeCheckbox: "./bower_components/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"
    },
    js: {
        jQuery: "./bower_components/jquery/dist/jquery.js",
        bootstrap_filestyle: "./bower_components/bootstrap-filestyle/src/bootstrap-filestyle.js"
    },
    font: {
        fontAwesome: "./bower_components/font-awesome/fonts/*"
    }
};
path.dest = {
    js: path.webroot + "js",
    css: path.webroot + "css",
    font: path.webroot + "fonts",
    font_azurefix: path.webroot + "css/fonts"
};


gulp.task("min:js", function () {
    return gulp.src([path.js.jQuery, path.js.bootstrap_filestyle])
        .pipe(concat(path.dest.js + "/site.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("copy:js", function () {
    return gulp.src([path.js.jQuery, path.js.bootstrap_filestyle])
        .pipe(gulp.dest(path.dest.js));
});

gulp.task("min:css", function () {
    return gulp.src([path.css.bootstrap, path.css.fontAwesome, path.css.awesomeCheckbox])
        .pipe(concat(path.dest.css + "/site.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("copy:css", function () {
    return gulp.src([path.css.bootstrap, path.css.fontAwesome, path.css.awesomeCheckbox])
        .pipe(gulp.dest(path.dest.css));
});

gulp.task("copy:fonts", function () {
    return gulp.src([path.font.fontAwesome])
        .pipe(gulp.dest(path.dest.font))
        .pipe(gulp.dest(path.dest.font_azurefix));
});

gulp.task("min", ["min:js", "min:css"]);
gulp.task("copy", ["copy:js", "copy:css", "copy:fonts"]);