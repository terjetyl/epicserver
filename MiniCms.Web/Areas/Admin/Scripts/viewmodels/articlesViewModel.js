(function() {
  var ShortDateLocalizer,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  window.ArticlesViewModel = (function(_super) {

    __extends(ArticlesViewModel, _super);

    ArticlesViewModel.name = 'ArticlesViewModel';

    function ArticlesViewModel(articles, categories) {
      this.articles = kb.collectionObservable(articles, {
        view_model: kb.ViewModel
      });
      this.categories = kb.collectionObservable(categories, {
        view_model: CategoryViewModel
      });
    }

    return ArticlesViewModel;

  })(kb.ViewModel);

  ShortDateLocalizer = (function(_super) {

    __extends(ShortDateLocalizer, _super);

    ShortDateLocalizer.name = 'ShortDateLocalizer';

    function ShortDateLocalizer(value, options, view_model) {
      ShortDateLocalizer.__super__.constructor.apply(this, arguments);
      return kb.utils.wrappedObservable(this);
    }

    ShortDateLocalizer.prototype.read = function(value) {};

    ShortDateLocalizer.prototype.write = function(localized_string, value) {};

    return ShortDateLocalizer;

  })(kb.LocalizedObservable);

}).call(this);
