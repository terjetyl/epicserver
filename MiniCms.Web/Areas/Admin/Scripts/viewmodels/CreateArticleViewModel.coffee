# @reference /scripts/knockback.js
# @reference CategoriesViewModel.js

class window.CreateArticleViewModel extends kb.ViewModel
	constructor: (model) ->
		super(model)
		@categories = kb.collectionObservable(model, {view_model: CategoryViewModel})
		@save = (title, body) ->
			article = new Article({ Title: title, Body: body })
			article.save()