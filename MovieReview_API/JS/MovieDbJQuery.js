$().ready(function() {

    $("#getMs").click(function() {

        $.get("http://localhost:50443/api/Review/", function (resp) {
            console.log(resp)
            showM(resp);
        });

    });

    function showM(movies) {
        var list = $("#mList");
        list.empty();
        for (i in movies) {
            var title = movies[i].Title;
            var genre = movies[i].Genre;
            var rDate = movies[i].ReleaseDate;
            list.append("<li>" + "Title: " + title + " | " + "Genre: " + genre + " | " + "Release Date: " + rDate + "</li>");
        }
    }
    var theMovie;
    var getMovie = function (movieId) {
        $.get("http://localhost:50443/api/Movie/" + movieId + "/", function (movie) {

            console.log(movie);
            theMovie = movie;
        });
        
    }
    var theUser;
    var getUser = function (userId) {
         $.get("http://localhost:50443/api/User/" + userId + "/", function (user) {
             theUser = user;
             console.log(user);
        });
    }

    $("#getRs").click(function () {

        $.get("http://localhost:50443/api/Review/", function (resp) {
            console.log(resp)
            showR(resp);
        });

    });

    function showR(reviews) {
        var list = $("#rList");
        list.empty();
        for (i in reviews) {
            var movieId = reviews[i].MovieId;
            getMovie(movieId);

            var movieName = theMovie.Title
            var userId = reviews[i].UserId;
            getUser(userId);

            var userName = theUser.Name
            var rating = reviews[i].Rating;
            list.append("<li>" + "Movie: " + movieName + " | " + "Reviewer: " + userName + " | " + "Rating (0 - 10): " + rating + "</li>");
        }
    }

    $("#getUs").click(function () {

        $.get("http://localhost:50443/api/User", function (resp) {
            console.log(resp)
            showU(resp);
        });

    });

    function showU(Users) {
        var list = $("#ulist");
        list.empty();
        for (i in Users) {
            var name = Users[i].Name;
            var age = Users[i].Age;
            var location = Users[i].Location;
            list.append("<li>" + "Name: " + name + " | "+ "Age: " + age + " | " + "Location: " + location + "</li>");
        }
    }
});