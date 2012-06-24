# @reference /scripts/knockback.js

class window.ArticlesViewModel
	constructor: (model) ->
		@articles = kb.collectionObservable(model, {view_model: kb.ViewModel})
		@save = (title, body) ->
			article = new Article({ Title: title, Body: body })
			article.save()