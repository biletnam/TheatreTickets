var gulp = require("gulp");

gulp.task("copyFiles", function () {
    gulp.src("./node_modules/bootstrap/**").pipe(gulp.dest("./wwwroot/lib/bootstrap"))
});