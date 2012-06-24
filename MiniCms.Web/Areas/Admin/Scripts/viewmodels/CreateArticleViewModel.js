(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  window.CreateArticleViewModel = (function(_super) {

    __extends(CreateArticleViewModel, _super);

    CreateArticleViewModel.name = 'CreateArticleViewModel';

    function CreateArticleViewModel(model) {
      CreateArticleViewModel.__super__.constructor.call(this, model);
      this.categories = kb.collectionObservable(model, {
        view_model: CategoryViewModel
      });
      this.save = function(title, body) {
        var article;
        article = new Article({
          Title: title,
          Body: body
        });
        return article.save();
      };
    }

    return CreateArticleViewModel;

  })(kb.ViewModel);

}).call(this);
