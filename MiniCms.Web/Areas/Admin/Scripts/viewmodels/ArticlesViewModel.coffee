# @reference /scripts/knockback.js

class window.ArticlesViewModel
	constructor: (model) ->
		@articles = kb.collectionObservable(model, {view_model: kb.ViewModel})