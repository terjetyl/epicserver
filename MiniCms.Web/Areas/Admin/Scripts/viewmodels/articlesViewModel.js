(function() {

  window.ArticlesViewModel = (function() {

    ArticlesViewModel.name = 'ArticlesViewModel';

    function ArticlesViewModel(model) {
      this.articles = kb.collectionObservable(model, {
        view_model: kb.ViewModel
      });
    }

    return ArticlesViewModel;

  })();

}).call(this);
