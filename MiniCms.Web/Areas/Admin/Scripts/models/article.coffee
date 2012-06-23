class window.Article extends Backbone.Model
	defaults:
		id: null
		title: ''
		body: ''
	urlRoot: '/api/articles'

class window.Articles extends Backbone.Collection
	model: Article
	url: '/api/articles'