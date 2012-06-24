(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  window.CategoriesViewModel = (function(_super) {

    __extends(CategoriesViewModel, _super);

    CategoriesViewModel.name = 'CategoriesViewModel';

    function CategoriesViewModel(model) {
      CategoriesViewModel.__super__.constructor.call(this, model);
      this.categories = kb.collectionObservable(model, {
        view_model: CategoryViewModel
      });
      this.checkAll = ko.observable(false);
      this.selectAll = function(checked) {
        var category, _i, _len, _ref;
        _ref = this.categories();
        for (_i = 0, _len = _ref.length; _i < _len; _i++) {
          category = _ref[_i];
          category.selected(this.checkAll() === false);
        }
        return true;
      };
      this.deleteSelected = function() {
        var category, _i, _len, _ref;
        _ref = this.categories();
        for (_i = 0, _len = _ref.length; _i < _len; _i++) {
          category = _ref[_i];
          if (category.selected()) {
            category.remove();
          }
        }
        return true;
      };
    }

    return CategoriesViewModel;

  })(kb.ViewModel);

  window.CategoryViewModel = (function(_super) {

    __extends(CategoryViewModel, _super);

    CategoryViewModel.name = 'CategoryViewModel';

    function CategoryViewModel(model) {
      var _this = this;
      CategoryViewModel.__super__.constructor.call(this, model);
      this.selected = ko.observable();
      this.remove = function() {
        console.log('remove');
        model.destroy();
        return true;
      };
    }

    return CategoryViewModel;

  })(kb.ViewModel);

}).call(this);
