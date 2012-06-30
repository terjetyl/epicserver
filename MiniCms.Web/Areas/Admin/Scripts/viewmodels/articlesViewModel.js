(function() {
  var LongDateLocalizer,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  window.ArticlesViewModel = (function(_super) {

    __extends(ArticlesViewModel, _super);

    ArticlesViewModel.name = 'ArticlesViewModel';

    function ArticlesViewModel(articles, categories) {
      this.articles = kb.collectionObservable(articles, {
        view_model: ArticleViewModel
      });
      this.categories = kb.collectionObservable(categories, {
        view_model: CategoryViewModel
      });
      this.checkAll = ko.observable(false);
      this.selectAll = function(checked) {
        var art, _i, _len, _ref;
        _ref = this.articles();
        for (_i = 0, _len = _ref.length; _i < _len; _i++) {
          art = _ref[_i];
          art.selected(this.checkAll() === false);
        }
        return true;
      };
    }

    return ArticlesViewModel;

  })(kb.ViewModel);

  window.ArticleViewModel = (function(_super) {

    __extends(ArticleViewModel, _super);

    ArticleViewModel.name = 'ArticleViewModel';

    function ArticleViewModel(model) {
      this.date = kb.observable(model, {
        key: 'DatePublished',
        localizer: LongDateLocalizer
      });
      this.title = kb.observable(model, {
        key: 'Title'
      });
      this.slug = kb.observable(model, {
        key: 'Slug'
      });
      this.commentcount = kb.observable(model, {
        key: 'CommentCount'
      });
      this.tags = kb.observable(model, {
        key: 'Tags'
      });
      this.author = kb.observable(model, {
        key: 'Author'
      });
      this.selected = ko.observable();
    }

    return ArticleViewModel;

  })(kb.ViewModel);

  LongDateLocalizer = kb.LocalizedObservable.extend({
    constructor: function(value, options, view_model) {
      kb.LocalizedObservable.prototype.constructor.apply(this, arguments);
      return kb.utils.wrappedObservable(this);
    },
    read: function(value) {
      return Globalize.format(new Date(value), 'dd MMMM yyyy', kb.locale_manager.getLocale());
    },
    write: function(localized_string, value) {
      var new_value;
      new_value = Globalize.parseDate(localized_string, 'dd MMMM yyyy', kb.locale_manager.getLocale());
      if (!(new_value && _.isDate(new_value))) {
        return kb.utils.wrappedObservable(this).resetToCurrent();
      }
      return value.setTime(new_value.valueOf());
    }
  });

}).call(this);
