# @reference /scripts/knockback.js

class window.CategoriesViewModel extends kb.ViewModel
	constructor: (model) ->
		super(model)
		@categories = kb.collectionObservable(model, {view_model: CategoryViewModel})
		@checkAll = ko.observable(false)
		@selectAll = (checked) ->
			for category in @categories()
				category.selected(@checkAll() == false)
			return true
		@deleteSelected = ->
			for category in @categories()
				if(category.selected())
					category.remove()
			return true
			

class CategoryViewModel extends kb.ViewModel
	constructor: (model) ->
		super(model)
		@selected = ko.observable()
		@remove = =>
			console.log 'remove'
			model.destroy()
			return true