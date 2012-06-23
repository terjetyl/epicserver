(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  window.Category = (function(_super) {

    __extends(Category, _super);

    Category.name = 'Category';

    function Category() {
      return Category.__super__.constructor.apply(this, arguments);
    }

    Category.prototype.idAttribute = 'Id';

    Category.prototype.urlRoot = '/api/categories';

    return Category;

  })(Backbone.Model);

  window.Categories = (function(_super) {

    __extends(Categories, _super);

    Categories.name = 'Categories';

    function Categories() {
      return Categories.__super__.constructor.apply(this, arguments);
    }

    Categories.prototype.model = Category;

    Categories.prototype.url = '/api/categories';

    return Categories;

  })(Backbone.Collection);

}).call(this);
