(function() {

  window.addcategory = function(name) {
    var category;
    category = {
      Name: name
    };
    return $.ajax('/api/categories', {
      type: 'POST',
      data: JSON.stringify(category),
      dataType: 'json',
      contentType: "application/json",
      error: function(jqXHR, textStatus, errorThrown) {
        return $('body').append("AJAX Error: " + textStatus);
      },
      success: function(data, textStatus, jqXHR) {
        return $('body').append("Successful AJAX call: " + data);
      }
    });
  };

  window.getcategories = function(callback) {
    return $.ajax('/api/categories', {
      type: 'GET',
      contentType: "application/json",
      dataType: 'json',
      error: function(jqXHR, textStatus, errorThrown) {
        return console.log("AJAX Error: " + textStatus);
      },
      success: function(data, textStatus, jqXHR) {
        return callback(data);
      }
    });
  };

  window.loadarticles = function() {
    var articles;
    return articles = new Articles;
  };

}).call(this);
