(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  window.Article = (function(_super) {

    __extends(Article, _super);

    Article.name = 'Article';

    function Article() {
      return Article.__super__.constructor.apply(this, arguments);
    }

    Article.prototype.idAttribute = 'Id';

    Article.prototype.urlRoot = '/api/articles';

    return Article;

  })(Backbone.Model);

  window.Articles = (function(_super) {

    __extends(Articles, _super);

    Articles.name = 'Articles';

    function Articles() {
      return Articles.__super__.constructor.apply(this, arguments);
    }

    Articles.prototype.model = Article;

    Articles.prototype.url = '/api/articles';

    return Articles;

  })(Backbone.Collection);

}).call(this);
