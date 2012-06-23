class window.Category extends Backbone.Model
	idAttribute: 'Id'
	urlRoot: '/api/categories'

class window.Categories extends Backbone.Collection
	model: Category
	url: '/api/categories'