# @reference /scripts/knockback.js
# @reference CategoriesViewModel.js

class window.ArticlesViewModel extends kb.ViewModel
	constructor: (articles, categories) ->
		@articles = kb.collectionObservable(articles, {view_model: kb.ViewModel})
		@categories = kb.collectionObservable(categories, {view_model: CategoryViewModel})

class ShortDateLocalizer extends kb.LocalizedObservable
	constructor: (value, options, view_model) ->
		super; return kb.utils.wrappedObservable(this)
	
	read: (value) -> # return something
	write: (localized_string, value) -> # do something