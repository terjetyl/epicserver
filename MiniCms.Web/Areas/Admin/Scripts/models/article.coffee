class window.Article extends Backbone.Model
	idAttribute: 'Id'
	urlRoot: '/api/articles'

class window.Articles extends Backbone.Collection
	model: Article
	url: '/api/articles'