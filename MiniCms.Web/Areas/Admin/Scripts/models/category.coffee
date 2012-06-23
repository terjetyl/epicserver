class window.Category extends Backbone.Model
	defaults:
		id: 0
		name: ''

class window.Categories extends Backbone.Collection
	model: Category
	localStorage: new Store("categories")