(function() {

  window.ArticlesViewModel = (function() {

    ArticlesViewModel.name = 'ArticlesViewModel';

    function ArticlesViewModel(model) {
      this.articles = kb.collectionObservable(model, {
        view_model: kb.ViewModel
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

    return ArticlesViewModel;

  })();

}).call(this);
